mod error;
mod generator;

use std::path::PathBuf;

use crate::error::Error;
use crate::generator::Generator;

const TAB: &str = "    ";

#[derive(Debug)]
pub struct Config {
    pub schema_dir: PathBuf,
    pub gen_dir: PathBuf,
}

impl Config {
    pub fn generate(self) -> Result<(), Error> {
        let mut generator = Generator::new(self);
        
        generator.compile()?;
        generator.collect()?;
        generator.generate()?;

        Ok(())
    }
}
