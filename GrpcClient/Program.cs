using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Calling a GRPC Service");
            Console.Write("Hit enter to do the deed");
            Console.ReadLine();
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Putintane" });

            Console.WriteLine($"Got the response {reply.Message}");

        }
    }
}
