package util

import (
	"encoding/binary"
	"errors"
	"google.golang.org/protobuf/proto"
)

const HeaderSize = 4

type ProtocolCategory uint8

const (
	None ProtocolCategory = iota
	Auth
	Game
	Net
)

type ProtocolHeader struct {
	category ProtocolCategory
	reserved uint8
	length   uint16
}

func SerializeProtocol(category ProtocolCategory, protocol proto.Message) ([]byte, error) {
	buf, err := proto.MarshalOptions{}.MarshalAppend(make([]byte, HeaderSize), protocol)
	if err != nil {
		return nil, err
	}

	if HeaderSize+len(buf) > 65536 {
		return nil, errors.New("protocol too large")
	}

	header := ProtocolHeader{
		category: category,
		reserved: 0,
		length:   uint16(len(buf) - HeaderSize),
	}
	err = SerializeHeader(header, buf)
	if err != nil {
		return nil, err
	}

	return buf, nil
}

func SerializeHeader(header ProtocolHeader, buf []byte) error {
	if len(buf) < HeaderSize {
		return errors.New("buffer size is too small")
	}

	binary.BigEndian.PutUint16(buf[:2], header.length)
	buf[2] = byte(header.category)
	//buf[3] = header.reserved

	return nil
}

func DeserializeHeader(buf []byte) (ProtocolHeader, error) {
	if len(buf) < HeaderSize {
		return ProtocolHeader{}, errors.New("buffer size is too small")
	}

	header := ProtocolHeader{
		category: ProtocolCategory(buf[0]),
		reserved: buf[1],
		length:   binary.BigEndian.Uint16(buf[2:]),
	}
	return header, nil
}
