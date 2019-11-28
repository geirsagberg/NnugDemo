using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using NnugDemo.Grpc;

namespace NnugDemo.GrpcClient
{
    internal class Program
    {
        private static async Task Main()
        {
            // The port number must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("https://localhost:5002");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest {Name = "NNUG"});
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
