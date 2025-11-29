use std::fs;

use glob::glob;
use serde::Deserialize;

use crate::*;

#[derive(Debug)]
pub struct Generator {
    config: Config,
    categories: Vec<Category>,
    protocol_entries: Vec<ProtocolEntry>,
}

#[derive(Debug, Deserialize)]
struct Category {
    category: String,
    offset: u16,
    protocols: Vec<Protocol>,
}

fn protocol_handle_default() -> bool { true }
#[derive(Debug, Deserialize)]
struct Protocol {
    protocol: String,
    target: ProtocolTarget,
    #[serde(default = "protocol_handle_default")]
    handle: bool,
}

#[derive(Debug, Deserialize)]
#[serde(rename_all = "lowercase")]
enum ProtocolTarget {
    Client,
    Server,
    All,
}

#[derive(Debug)]
struct ProtocolEntry {
    category: String,
    number: u16,
    protocol: Protocol,
}

impl Generator {
    pub fn new(config: Config) -> Self {
        Self {
            config,
            categories: Vec::new(),
            protocol_entries: Vec::new(),
        }
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

        for mut category in self.categories.drain(..) {
            let mut number = category.offset;

            for protocol in category.protocols.drain(..) {
                self.protocol_entries.push(ProtocolEntry {
                    category: category.category.clone(),
                    number,
                    protocol,
                });
                number += 1;
            }
        }

        Ok(())
    }

    pub fn generate(&self) -> Result<(), Error> {
        if self.config.generate_impl {
            self.generate_impl()?;
        }

        if self.config.generate_handle {
            self.generate_handle()?;
        }

        Ok(())
    }

    fn generate_impl(&self) -> Result<(), Error> {
        let mut protocol_impls = Vec::new();

        for entry in &self.protocol_entries {
            let protocol_full_name = format!("{}::{}", entry.category, entry.protocol.protocol);

            protocol_impls.push(format!(r#"
impl crate::game::Protocol for {protocol_full_name} {{
    fn protocol_id(&self) -> crate::game::ProtocolId {{ {protocol_number} }}
}}
"#,
            protocol_number = entry.number,
            ));
        }

        let code = format!(r#"
{protocol_impls_code}
        "#,
           protocol_impls_code = protocol_impls.join("\n"),
        );

        let gen_file = PathBuf::from(&self.config.gen_dir).join("spire.protocol.game.impl.rs");
        fs::write(gen_file, &code)?;

        Ok(())
    }

    fn generate_handle(&self) -> Result<(), Error> {
        let mut protocol_handles = Vec::new();

        for entry in &self.protocol_entries {
            let protocol_full_name = format!("protocol::game::{}::{}", entry.category, entry.protocol.protocol);

            if !entry.protocol.handle {
                continue;
            }

            match &entry.protocol.target {
                ProtocolTarget::Server | ProtocolTarget::All => {},
                _ => continue,
            }

            protocol_handles.push(format!(
                "{TAB}{TAB}{} => {protocol_full_name}::decode(data)?.handle(ctx).await,",
                entry.number,
            ));
        }

        let code = format!(r#"use prost::Message;

pub async fn decode_and_handle(
    id: protocol::game::ProtocolId,
    data: bytes::Bytes,
    ctx: &crate::net::session::SessionContext,
) -> Result<(), protocol::game::Error> {{
    Ok(match id {{
{protocol_handles_code}
        _ => return Err(protocol::game::Error::ProtocolId(id)),
    }})
}}
        "#,
           protocol_handles_code = protocol_handles.join("\n"),
        );

        let gen_file = PathBuf::from(&self.config.gen_dir).join("spire.protocol.game.handle.rs");
        fs::write(gen_file, &code)?;

        Ok(())
    }
}
