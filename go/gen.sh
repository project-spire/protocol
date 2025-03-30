#!/bin/bash

SCHEMA_PATH=$1
GEN_PATH=$2
SCHEMAS=$(find ${SCHEMA_PATH} -name "*.proto")

mkdir -p ${GEN_PATH}

protoc -I=${SCHEMA_PATH} --go_out=${GEN_PATH} --go_opt=paths=source_relative ${SCHEMAS}
#protoc -I=${SCHEMA_PATH} --go_out=${GEN_PATH} ${SCHEMAS}