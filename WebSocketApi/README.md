This is a sample which uses Protocol Buffers to communicate binary objects over Websockets.

It uses https://github.com/dcodeIO/ProtoBuf.js/ client side in a webpage 

to send to .Net Server Side WebApiController listening for WebSockets.

protobuf-net https://github.com/mgravell/protobuf-net

is on the server to decode objects from client and recode new objects to send.

This is using 
https://www.nuget.org/packages/protobuf-net/2.0.0.480

And doesn't work with the latest version, but will in a future release.