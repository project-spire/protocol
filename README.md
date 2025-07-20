# Spire Game Protocol

## Protocol Header Format

* Total 4 bytes.
* Length does not include header.

| Bytes | Content  |
|------:|----------|
|     0 | Category |
|     1 | Reserved |
|   2~3 | Length   |


## Protocol Category

| Value | Category |
|------:|----------|
|     0 | None     |
|     1 | Auth     |
|     2 | Net      |
|     3 | Game     |
