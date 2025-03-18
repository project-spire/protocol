use glob::glob;
use std::path::PathBuf;

fn main() -> Result<(), Box<dyn std::error::Error>> {
    let proto_files: Vec<PathBuf> = glob("../schemas/**/*.proto")?
        .filter_map(Result::ok)
        .collect();
    
    for proto_file in &proto_files {
        println!("cargo:rerun-if-changed={}", proto_file.display());
    }
    
    prost_build::compile_protos(&proto_files, &["../schemas/"])?;

    Ok(())
}
