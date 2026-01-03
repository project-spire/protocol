
# Game

## Protocol Header

| Offset | Field | Size | Description |
| :----:  | :--------: | :------: | :------------ |
| 0 - 1 | Length | 2 Bytes | The total size of the protocol **excluding** header size. |
| 2 - 3 | Protocol ID | 2 Bytes | An unique identifier for the protocol type. |

## Protocols

| Category | ID | Name | Target |
|:--------:|---:|:----:|:------:|
|auth|1|Login|Server|
|auth|2|LoginResult|Client|
|net|100|Ping|All|
|net|101|Pong|All|
|net|102|ZoneTransfer|Client|
|net|103|ZoneTransferReady|Server|
|net|104|ZoneTransferReadyResult|Client|
|tool|200|Cheat|Server|
|tool|201|CheatResult|Client|
|play|10000|EntitySpawn|Client|
|play|10001|EntityDespawn|Client|
|play|10002|ItemPickup|Server|
|play|10003|ItemPickupResult|Client|
|play|10004|MovementCommand|Server|
|play|10005|MovementSync|Client|
|play|10006|SkillCancel|Server|
|play|10007|SkillCancelResult|Client|
|play|10008|SkillUse|Server|
|play|10009|SkillUseResult|Client|
|play|10010|SkillUseSync|Client|
|social|20000|PartyCreate|Server|
|social|20001|PartyCreateResult|Client|
|social|20002|PartyInvite|Server|
|social|20003|PartyInviteResult|Client|
