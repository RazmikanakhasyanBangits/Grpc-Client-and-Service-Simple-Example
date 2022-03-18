using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc_Service_Usage;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:5036");
var client = new Greeter.GreeterClient(channel);
responseModel reply = await client.CustomReplyAsync(new requestModel() { Max = 1 });

Console.WriteLine("Greeting: " + reply.MaxResult);
Console.WriteLine("Press any key to exit...");