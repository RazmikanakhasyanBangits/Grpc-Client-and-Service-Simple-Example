using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using Grpc.Net.Client;
using Grpc_Service_Usage;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:5036");

var client = new Greeter.GreeterClient(channel);
while (true)
{

    string? name = Console.ReadLine();
    responseModel reply = await client.CustomReplyAsync(new requestModel() { Name = name });
    Console.WriteLine("User: " + JsonSerializer.Serialize(reply));

}