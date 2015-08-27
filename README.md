# CSharpWebSocketProtoBuf

Protocol Buffers from C# WebSocket to protobuf.js example, with complex object example

protobuf-net for reading protocol buffers on the server.

Currently using AspNetWebSocket and limited by ArraySegment to fill incoming buffer.
Set to 1k and extra trimmed, but very large or very small objects should be allowed
to be sent and processed so may look at other backend alternatives.
