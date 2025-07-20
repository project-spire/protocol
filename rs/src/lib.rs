use bytes::{BufMut, Bytes, BytesMut};
use std::error::Error;
pub use prost::Message;

pub const PROTOCOL_HEADER_SIZE: usize = 4;

#[derive(Eq, PartialEq, Debug)]
pub enum ProtocolCategory {
    Auth = 1,
    Net = 2,
    Game = 3,
}

pub fn decode_header(buf: &[u8; PROTOCOL_HEADER_SIZE]) -> Result<(ProtocolCategory, usize), std::io::Error> {
    let category = match buf[0] {
        1 => ProtocolCategory::Auth,
        2 => ProtocolCategory::Net,
        3 => ProtocolCategory::Game,
        _ => return Err(std::io::Error::new(
            std::io::ErrorKind::InvalidData, "Invalid protocol category")),
    };
    let length =  ((buf[2] as usize) << 8) | (buf[3] as usize);

    Ok((category, length))
}

include!(concat!(env!("OUT_DIR"), "/spire.protocol.rs"));

pub fn encode<T: prost::Message>(category: ProtocolCategory, protocol: &T) -> Result<Bytes, std::io::Error> {
    const RESERVED: u8 = 0u8;

    let length = protocol.encoded_len();
    if length > u16::MAX as usize {
        return Err(std::io::Error::new(
            std::io::ErrorKind::InvalidData, "Protocol too large"));
    }

    let mut buf = BytesMut::with_capacity(PROTOCOL_HEADER_SIZE + length);

    // Header
    buf.put_u8(category as u8);
    buf.put_u8(RESERVED);
    buf.put_u8((length >> 8) as u8);
    buf.put_u8(length as u8);

    // Body
    if let Err(_) = protocol.encode(&mut buf) {
        return Err(std::io::Error::new(
            std::io::ErrorKind::Other, "Failed to encode body"));
    }

    Ok(buf.freeze())
}

pub mod auth {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.auth.rs"));

    pub fn encode<T: prost::Message>(protocol: &T) -> Result<bytes::Bytes, std::io::Error> {
        crate::encode::<T>(crate::ProtocolCategory::Auth, protocol)
    }
}

pub mod net {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.net.rs"));

    pub fn encode<T: prost::Message>(protocol: &T) -> Result<bytes::Bytes, std::io::Error> {
        crate::encode::<T>(crate::ProtocolCategory::Net, protocol)
    }
}

pub mod game {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.game.rs"));

    pub fn encode<T: prost::Message>(protocol: &T) -> Result<bytes::Bytes, std::io::Error> {
        crate::encode::<T>(crate::ProtocolCategory::Game, protocol)
    }
}

pub mod convert {
    use crate::*;
    use nalgebra::{Point2, Vector2};

    impl From<Vector2<f32>> for PVector2 {
        fn from(value: Vector2<f32>) -> Self {
            PVector2 { x: value.x, y: value.y }
        }
    }

    impl From<PVector2> for Vector2<f32> {
        fn from(value: PVector2) -> Self {
            Vector2::new(value.x, value.y)
        }
    }

    impl From<Point2<f32>> for PPoint2 {
        fn from(value: Point2<f32>) -> Self {
            PPoint2 { x: value.x, y: value.y }
        }
    }

    impl From<PPoint2> for Point2<f32> {
        fn from(value: PPoint2) -> Self {
            Point2::new(value.x, value.y)
        }
    }
}
