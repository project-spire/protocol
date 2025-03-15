pub mod auth {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.auth.rs"));
}

pub mod game {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.game.rs"));
}

pub mod net {
    include!(concat!(env!("OUT_DIR"), "/spire.protocol.net.rs"));
}

pub enum Protocol {
    None = 0,
    Auth = 1,
    Game = 2,
    Net = 3,
}

pub fn write_header(protocol: Protocol, length: u16, buf: &mut [u8; 4]) {
    const RESERVED: u8 = 0u8;

    buf[0] = protocol as u8;
    buf[1] = RESERVED;
    buf[2] = (length >> 8) as u8;
    buf[3] = length as u8;
}

pub fn read_header(buf: &[u8; 4]) -> (Protocol, u16) {
    let protocol = match buf[0] {
        1 => Protocol::Auth,
        2 => Protocol::Game,
        3 => Protocol::Net,
        _ => Protocol::None,
    };
    let length =  ((buf[2] as u16) << 8) | (buf[3] as u16);

    (protocol, length)
}
