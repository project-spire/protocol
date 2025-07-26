use bytes::{BufMut, Bytes, BytesMut};
use std::fmt::{Display, Formatter};
pub use prost::Message;

pub const PROTOCOL_HEADER_SIZE: usize = 4;

#[derive(Eq, PartialEq, Debug)]
pub enum ProtocolCategory {
    Auth = 1,
    Net = 2,
    Game = 3,
}

pub fn decode_header(buf: &[u8; PROTOCOL_HEADER_SIZE]) -> Result<(ProtocolCategory, usize), ProtocolError> {
    let category = match buf[0] {
        1 => ProtocolCategory::Auth,
        2 => ProtocolCategory::Net,
        3 => ProtocolCategory::Game,
        _ => return Err(ProtocolError::InvalidHeader),
    };
    let length =  ((buf[2] as usize) << 8) | (buf[3] as usize);

    Ok((category, length))
}

include!(concat!(env!("OUT_DIR"), "/spire.protocol.rs"));

pub fn encode<T: prost::Message>(category: ProtocolCategory, protocol: &T) -> Result<Bytes, ProtocolError> {
    const RESERVED: u8 = 0u8;

    let length = protocol.encoded_len();
    if length > u16::MAX as usize {
        return Err(ProtocolError::EncodeError);
    }

    let mut buf = BytesMut::with_capacity(PROTOCOL_HEADER_SIZE + length);

    // Header
    buf.put_u8(category as u8);
    buf.put_u8(RESERVED);
    buf.put_u8((length >> 8) as u8);
    buf.put_u8(length as u8);

    // Body
    if let Err(_) = protocol.encode(&mut buf) {
        return Err(ProtocolError::EncodeError);
    }

    Ok(buf.freeze())
}

#[derive(Debug)]
pub enum ProtocolError {
    InvalidHeader,
    InvalidData,
    EncodeError,
}

impl Display for ProtocolError {
    fn fmt(&self, f: &mut Formatter<'_>) -> std::fmt::Result {
        match self {
            ProtocolError::InvalidHeader => write!(f, "Invalid protocol header"),
            ProtocolError::InvalidData => write!(f, "Invalid protocol data"),
            ProtocolError::EncodeError => write!(f, "Failed to encode protocol"),
        }
    }
}

impl std::error::Error for ProtocolError {}

pub mod auth {
    use crate::ProtocolError;

    include!(concat!(env!("OUT_DIR"), "/spire.protocol.auth.rs"));

    pub fn encode<T: prost::Message>(protocol: &T) -> Result<bytes::Bytes, ProtocolError> {
        crate::encode::<T>(crate::ProtocolCategory::Auth, protocol)
    }
}

pub mod net {
    use crate::ProtocolError;

    include!(concat!(env!("OUT_DIR"), "/spire.protocol.net.rs"));

    pub fn encode<T: prost::Message>(protocol: &T) -> Result<bytes::Bytes, ProtocolError> {
        crate::encode::<T>(crate::ProtocolCategory::Net, protocol)
    }
}

pub mod game {
    use crate::ProtocolError;

    include!(concat!(env!("OUT_DIR"), "/spire.protocol.game.rs"));

    pub fn encode<T: prost::Message>(protocol: &T) -> Result<bytes::Bytes, ProtocolError> {
        crate::encode::<T>(crate::ProtocolCategory::Game, protocol)
    }
}

pub mod convert {
    use crate::*;
    use nalgebra::{Point2, Point3, UnitVector2, Vector2, Vector3};

    impl From<Vector2<f32>> for PVector2 {
        fn from(v: Vector2<f32>) -> Self {
            PVector2 { x: v.x, y: v.y }
        }
    }

    impl From<PVector2> for Vector2<f32> {
        fn from(v: PVector2) -> Self {
            Vector2::new(v.x, v.y)
        }
    }

    impl From<Vector3<f32>> for PVector3 {
        fn from(v: Vector3<f32>) -> Self {
            PVector3 { x: v.x, y: v.y, z: v.z }
        }
    }

    impl From<PVector3> for Vector3<f32> {
        fn from(v: PVector3) -> Self {
            Vector3::new(v.x, v.y, v.z)
        }
    }

    impl From<Point2<f32>> for PVector2 {
        fn from(p: Point2<f32>) -> Self {
            PVector2 { x: p.x, y: p.y }
        }
    }

    impl From<PVector2> for Point2<f32> {
        fn from(v: PVector2) -> Self {
            Point2::new(v.x, v.y)
        }
    }

    impl From<Point3<f32>> for PVector3 {
        fn from(p: Point3<f32>) -> Self {
            PVector3 { x: p.x, y: p.y, z: p.z }
        }
    }

    impl From<PVector3> for Point3<f32> {
        fn from(v: PVector3) -> Self {
            Point3::new(v.x, v.y, v.z)
        }
    }

    impl From<PVector2> for UnitVector2<f32> {
        fn from(v: PVector2) -> Self {
            let v = Vector2::new(v.x, v.y);
            if v.x == 0.0 && v.y == 0.0 {
                UnitVector2::new_normalize(Vector2::new(1.0, 0.0))
            } else {
                UnitVector2::new_normalize(v)
            }
        }
    }

    impl From<UnitVector2<f32>> for PVector2 {
        fn from(v: UnitVector2<f32>) -> Self {
            PVector2 { x: v.x, y: v.y }
        }
    }

    impl From<Uuid> for uuid::Uuid {
        fn from(value: Uuid) -> Self {
            uuid::Uuid::from_u64_pair(value.high, value.low)
        }
    }

    impl From<uuid::Uuid> for Uuid {
        fn from(value: uuid::Uuid) -> Self {
            let (high, low) = value.as_u64_pair();
            Uuid { high, low }
        }
    }
}
