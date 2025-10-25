use std::fs;

use glob::glob;
use serde::Deserialize;

use crate::*;

#[derive(Debug)]
pub struct Generator {
    config: Config,
    categories: Vec<Category>,
    protocols: Vec<Protocol>,
}

#[derive(Debug, Deserialize)]
struct Category {
    category: String,
    offset: u16,
    protocols: Vec<String>,
}

#[derive(Debug)]
struct Protocol {
    category: String,
    name: String,
    number: u16,
}

impl Generator {
    pub fn new(config: Config) -> Self {
        Self {
            config,
            categories: Vec::new(),
            protocols: Vec::new(),
        }
    }

    pub fn compile(&self) -> Result<(), Error> {
        fn find(schema_base_dir: &PathBuf, schema_dir: &PathBuf) -> Vec<PathBuf> {
            let schemas: Vec<PathBuf> = [
                schema_base_dir.join("*.proto").to_str().unwrap(),
                schema_dir.join("**/*.proto").to_str().unwrap(),
            ]
            .iter()
            .flat_map(|pattern| glob(pattern).unwrap())
            .filter_map(Result::ok)
            .collect();

            schemas
        }

        let schema_base_dir = &self.config.schema_dir;

        // Game protocols
        let schema_dir = schema_base_dir.join("game");
        let schemas = find(schema_base_dir, &schema_dir);

        for schema in &schemas {
            println!("cargo:rerun-if-changed={}", schema.display());
        }

        prost_build::compile_protos(&schemas, &[schema_base_dir, &schema_dir])?;

        // Lobby protocols
        let schema_dir = schema_base_dir.join("lobby");
        let schemas = find(schema_base_dir, &schema_dir);

        for schema in &schemas {
            println!("cargo:rerun-if-changed={}", schema.display());
        }
        tonic_prost_build::configure().compile_protos(&schemas, &[schema_base_dir.clone(), schema_dir])?;

        Ok(())
    }

    pub fn collect(&mut self) -> Result<(), Error> {
        let category_files: Vec<PathBuf> = glob(self.config.schema_dir.join("game/*.json").to_str().unwrap())
            .unwrap()
            .filter_map(Result::ok)
            .collect();

        for category_file in &category_files {
            let category: Category = serde_json::from_str(&fs::read_to_string(&category_file)?)?;
            self.categories.push(category);
        }

        for category in &self.categories {
            let mut number = category.offset;
            for protocol in &category.protocols {
                self.protocols.push(Protocol {
                    category: category.category.clone(),
                    name: protocol.clone(),
                    number
                });
                number += 1;
            }
        }

        Ok(())
    }

    pub fn generate(&self) -> Result<(), Error> {
        let mut protocol_decodes = Vec::new();
        let mut protocol_impls = Vec::new();

        for protocol in &self.protocols {
            let protocol_full_name = format!("{}::{}", protocol.category, protocol.name);

            protocol_decodes.push(format!(
                "{TAB}{TAB}{} => Box::new({protocol_full_name}::decode(buf)?),",
                protocol.number,
            ));

            protocol_impls.push(format!(r#"
impl crate::game::Protocol for {protocol_full_name} {{
    fn protocol_id(&self) -> u16 {{ {protocol_number} }}
    fn as_any(&self) -> &dyn std::any::Any {{ self }}
}}
"#,
            protocol_number = protocol.number,
            ));
        }

        let code = format!(r#"
pub fn decode(id: u16, buf: bytes::Bytes) -> Result<Box<dyn crate::game::Protocol>, Error> {{
    Ok(match id {{
{protocol_decodes_code}
        _ => return Err(Error::ProtocolId(id)),
    }})
}}

{protocol_impls_code}
        "#,
            protocol_decodes_code = protocol_decodes.join("\n"),
            protocol_impls_code = protocol_impls.join("\n"),
        );

        let gen_file = PathBuf::from(&self.config.gen_dir).join("spire.protocol.game.impl.rs");
        fs::write(gen_file, &code)?;

        Ok(())
    }
}
