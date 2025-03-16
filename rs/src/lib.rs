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

pub const HEADER_SIZE: usize = 4;

#[derive(Eq, PartialEq, Debug)]
pub enum ProtocolCategory {
    None = 0,
    Auth = 1,
    Game = 2,
    Net = 3,
}

pub fn write_header(category: ProtocolCategory, length: u16, buf: &mut [u8; HEADER_SIZE]) {
    const RESERVED: u8 = 0u8;

    buf[0] = category as u8;
    buf[1] = RESERVED;
    buf[2] = (length >> 8) as u8;
    buf[3] = length as u8;
}

pub fn read_header(buf: &[u8; HEADER_SIZE]) -> (ProtocolCategory, u16) {
    let category = match buf[0] {
        1 => ProtocolCategory::Auth,
        2 => ProtocolCategory::Game,
        3 => ProtocolCategory::Net,
        _ => ProtocolCategory::None,
    };
    let length =  ((buf[2] as u16) << 8) | (buf[3] as u16);

    (category, length)
}
