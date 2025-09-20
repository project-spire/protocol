use std::{env, fs};
use std::path::PathBuf;
use glob::glob;
use serde::Deserialize;

const SCHEMA_BASE_DIR: &str = "../../schema";

fn main() -> Result<(), Box<dyn std::error::Error>> {
    // Game protocols
    let schema_base_dir = PathBuf::from(SCHEMA_BASE_DIR);
    let schema_dir = schema_base_dir.join("game");
    let schemas: Vec<PathBuf> = [
        schema_base_dir.join("*.proto").to_str().unwrap(),
        schema_dir.join("**/*.proto").to_str().unwrap(),
    ]
        .iter()
        .flat_map(|pattern| glob(pattern).unwrap())
        .filter_map(Result::ok)
        .collect();

    for schema in &schemas {
        println!("cargo:rerun-if-changed={}", schema.display());
    }

    prost_build::compile_protos(&schemas, &[&schema_base_dir, &schema_dir])?;

    // Game protocols implementation
    generate_game_impl_code(&schema_dir)?;

    // Lobby protocols
    let schema_dir = schema_base_dir.join("lobby");
    let schemas: Vec<PathBuf> = [
        schema_base_dir.join("*.proto").to_str().unwrap(),
        schema_dir.join("**/*.proto").to_str().unwrap(),
    ]
        .iter()
        .flat_map(|pattern| glob(pattern).unwrap())
        .filter_map(Result::ok)
        .collect();

    for schema in &schemas {
        println!("cargo:rerun-if-changed={}", schema.display());
    }

    tonic_prost_build::configure().compile_protos(
        &schemas,
        &[schema_base_dir, schema_dir],
    )?;

    Ok(())
}

fn generate_game_impl_code(schema_dir: &PathBuf) -> Result<(), Box<dyn std::error::Error>> {
    const TAB: &str = "    ";
    const CRATE_PREFIX: &str = "crate::game";

    let category_files: Vec<PathBuf> = glob(schema_dir.join("*.json").to_str().unwrap())?
        .filter_map(Result::ok)
        .collect();

    let mut categories = Vec::new();
    let mut protocols = Vec::new();

    for category_file in &category_files {
        let category: Category = serde_json::from_str(
            &fs::read_to_string(&category_file)?
        )?;
        categories.push(category);
    }

    for category in &categories {
        let mut number = category.offset;
        for protocol in &category.protocols {
            protocols.push((&category.category, protocol, number));
            number += 1;
        }
    }

    let mut enums = Vec::new();
    let mut decode_matches = Vec::new();
    let mut id_impls = Vec::new();

    for (category, protocol_name, number) in protocols {
        let protocol_full_name = format!("{}::{}",
                                         category,
                                         protocol_name,
        );

        enums.push(format!(
            "{TAB}{protocol_name}({protocol_full_name}),",
        ));

        decode_matches.push(format!(
            "{TAB}{TAB}{TAB}{number} => Self::{protocol_name}({protocol_full_name}::decode(data)?),",
        ));

        id_impls.push(format!(
            r#"impl {CRATE_PREFIX}::Protocolic for {protocol_full_name} {{
    fn protocol_id(&self) -> u16 {{ {number} }}
}}
"#
        ));
    }

    let code = format!(
        r#"// Generated file

#[derive(Debug)]
pub enum Protocol {{
{enums_code}
}}

impl Protocol {{
    pub fn decode(id: u16, data: bytes::Bytes) -> Result<Self, Box<dyn std::error::Error>> {{
        Ok(match id {{
{decode_matches_code}
            _ => return Err(InvalidProtocolId(id).into()),
        }})
    }}
}}

#[derive(Debug)]
struct InvalidProtocolId(u16);

impl std::error::Error for InvalidProtocolId {{}}

impl std::fmt::Display for InvalidProtocolId {{
    fn fmt(&self, f: &mut std::fmt::Formatter) -> std::fmt::Result {{
        write!(f, "Invalid protocol id: {{}}", self.0)
    }}
}}

{id_impls_code}"#,
        enums_code = enums.join("\n"),
        decode_matches_code = decode_matches.join("\n"),
        id_impls_code = id_impls.join("\n"),
    );

    let out_dir = env::var("OUT_DIR").unwrap();
    let gen_file = PathBuf::from(&out_dir).join("spire.protocol.game.impl.rs");

    fs::write(gen_file, &code)?;

    Ok(())
}

#[derive(Deserialize)]
struct Category {
    category: String,
    offset: u16,
    protocols: Vec<String>,
}
