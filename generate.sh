#!/bin/bash

shopt -s globstar
files=(**/*.proto)

mkdir -p gen

protoc \
    --proto_path=schemas \
    --csharp_out=gen \
    --csharp_opt=file_extension=.g.cs \
    "${files[@]}"
