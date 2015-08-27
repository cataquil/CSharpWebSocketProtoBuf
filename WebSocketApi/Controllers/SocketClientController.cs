using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.WebSockets;
using WebSocketApi.Models;
using ProtoBuf;

namespace WebSocketApi.Controllers
{
    public class SocketClientController : ApiController
    {
        public HttpResponseMessage Get()
        {
            if (HttpContext.Current.IsWebSocketRequest)
            {
                HttpContext.Current.AcceptWebSocketRequest(ProcessProtoBufDecodeRecode);  
            }
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        private async Task ProcessProtoBufDecodeRecode(AspNetWebSocketContext context)
        {
            System.Net.WebSockets.WebSocket socket = context.WebSocket;
            while (true)
            {
                ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None);
                var inputStream = new System.IO.MemoryStream(buffer.Array, buffer.Offset, buffer.Count);

                TestObject msg = Serializer.Deserialize<TestObject>(inputStream);

                if (socket.State == WebSocketState.Open)
                {
                    msg.Name = "now I change you";
                    msg.TestId = 12;
                    msg.IsWorking = true;
                    msg.Priority = Priority.HIGH;
                    msg.Balance = 876.54321;
                    msg.Contacts.Add(new Contact
                    {
                        Name = "Jo",
                        ContactDetails = "jo@foobar.inc"
                    });
                    msg.Contacts.Add(new Contact
                    {
                        Name = "Fred",
                        ContactDetails = "01234121412"
                    });

                    ArraySegment<byte> outputBuffer;

                    using (var serializationBuffer = new System.IO.MemoryStream())
                    {
                        Serializer.Serialize(serializationBuffer, msg);
                        outputBuffer = new ArraySegment<byte>(serializationBuffer.GetBuffer(), 0, (int)serializationBuffer.Length);
                    }

                    await socket.SendAsync(outputBuffer, WebSocketMessageType.Binary, true, CancellationToken.None);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
