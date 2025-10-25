include!(concat!(env!("OUT_DIR"), "/spire.protocol.game.impl.rs"));

pub mod auth {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.game.auth.rs"));
}

pub mod net {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.game.net.rs"));
}

pub mod play {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.game.play.rs"));
}

use std::any::Any;

use bytes::{BufMut, Bytes, BytesMut};
use prost::Message;

pub struct Header {
    pub length: usize,
    pub id: u16,
}

impl Header {
    pub const fn size() -> usize {
        4
    }

    pub fn encode(buf: &mut BytesMut, length: usize, id: u16) -> Result<(), Error> {
        if buf.remaining_mut() < Self::size() {
            return Err(Error::NotEnoughBuffer(buf.remaining_mut(), Self::size()));
        }

        buf.put_u8((length >> 8) as u8);
        buf.put_u8(length as u8);
        buf.put_u8((id >> 8) as u8);
        buf.put_u8(id as u8);

        Ok(())
    }

    pub fn decode(buf: &[u8; Self::size()]) -> Result<Self, Error> {
        let length = ((buf[0] as usize) << 8) | (buf[1] as usize);
        let protocol = ((buf[2] as u16) << 8) | (buf[3] as u16);

        Ok(Self {
            length,
            id: protocol,
        })
    }
}

pub trait Protocol: Any {
    fn protocol_id(&self) -> u16;
    
    fn handle(&self) {
        unimplemented!("Protocol handler for id {} is not implemented", self.protocol_id());
    }
    
    fn as_any(&self) -> &dyn Any;
}

pub fn encode(protocol: &(impl prost::Message + Protocol)) -> Result<Bytes, Error> {
    let length = protocol.encoded_len();
    if length > u16::MAX as usize {
        return Err(Error::ProtocolLength(length));
    }

    let mut buf = BytesMut::with_capacity(Header::size() + length);

    Header::encode(&mut buf, length, protocol.protocol_id())?;
    protocol.encode(&mut buf)?;

    Ok(buf.freeze())
}

#[derive(Debug, thiserror::Error)]
pub enum Error {
    #[error("Invalid protocol length: {0}")]
    ProtocolLength(usize),

    #[error("Invalid protocol ID: {0}")]
    ProtocolId(u16),

    #[error("Not enough buffer size {0} for {1}")]
    NotEnoughBuffer(usize, usize),

    #[error("Failed to encode: {0}")]
    Encode(#[from] prost::EncodeError),

    #[error("Failed to decode: {0}")]
    Decode(#[from] prost::DecodeError),

    #[error("Unhandled protocol id: {0}")]
    UnhandledProtocol(u16),
}
