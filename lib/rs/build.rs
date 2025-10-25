use std::env;
use std::path::PathBuf;
use std::process::exit;

fn main() {
    let config = protocol_generator::Config {
        schema_dir: PathBuf::from("../../schema"),
        gen_dir: PathBuf::from(env::var("OUT_DIR").unwrap()),
    };

    if let Err(e) = config.generate() {
        eprintln!("Failed to generate: {}", e);
        exit(1);
    }
}
