use glob::glob;
use std::path::PathBuf;

fn main() -> Result<(), Box<dyn std::error::Error>> {
    // Compile protocols
    println!("cargo:rerun-if-changed=../schemas/");
    let proto_files: Vec<PathBuf> = glob("../schemas/**/*.proto")?
        .filter_map(Result::ok)
        .collect();
    prost_build::compile_protos(&proto_files, &["../schemas/"])?;

    Ok(())
}
