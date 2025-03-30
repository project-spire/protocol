include!(concat!(env!("OUT_DIR"), "/spire.protocol.rs"));

pub mod auth {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.auth.rs"));
}

pub mod game {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.game.rs"));
}

pub mod net {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.net.rs"));
}

pub use prost::Message;
use prost::EncodeError;

pub const HEADER_SIZE: usize = 4;

#[derive(Eq, PartialEq, Debug)]
pub enum ProtocolCategory {
    None = 0,
    Auth = 1,
    Game = 2,
    Net = 3,
}

#[derive(Debug, Clone)]
pub enum SerializeError {
    BodyLengthExceeded,
    EncodeError(EncodeError),
}

pub fn serialize_protocol<T: prost::Message>(category: ProtocolCategory, protocol: &T) -> Result<Vec<u8>, SerializeError> {
    let length = protocol.encoded_len();
    if length > u16::max as usize {
        return Err(SerializeError::BodyLengthExceeded);
    }

    let mut buf = Vec::with_capacity(HEADER_SIZE + length);
    serialize_header(category, length as u16, &mut buf[..HEADER_SIZE].try_into().unwrap());
    if let Err(e) = protocol.encode(&mut buf) {
        return Err(SerializeError::EncodeError(e));
    }

    Ok(buf)
}

pub fn serialize_header(
    category: ProtocolCategory,
    length: u16,
    buf: &mut [u8; HEADER_SIZE]
) {
    const RESERVED: u8 = 0u8;

    buf[0] = category as u8;
    buf[1] = RESERVED;
    buf[2] = (length >> 8) as u8;
    buf[3] = length as u8;
}

pub fn deserialize_header(buf: &[u8; HEADER_SIZE]) -> (ProtocolCategory, u16) {
    let category = match buf[0] {
        1 => ProtocolCategory::Auth,
        2 => ProtocolCategory::Game,
        3 => ProtocolCategory::Net,
        _ => ProtocolCategory::None,
    };
    let length =  ((buf[2] as u16) << 8) | (buf[3] as u16);

    (category, length)
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
