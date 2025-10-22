// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcGreeterClient;

using var channel = GrpcChannel.ForAddress("http://localhost:5231");
//var client = new Greeter.GreeterClient(channel);
//var reply = await client.SayHelloAsync(
//    new HelloRequest { Name = "GreeterClient -Himel" });
//Console.WriteLine("Greeting: " + reply.Message);
//Console.WriteLine("Press any key to exit...");
//Console.ReadKey();
var client = new JsonConfig.JsonConfigClient(channel);
var reply = await client.SendJsonConfigAsync(
    new JsonRequest { Id = "be0a34c5-db09-4b55-825a-9534471aa2e3" });
Console.WriteLine("ConfigJson: " + reply.ConfigJson);
Console.WriteLine("PayloadJson: " + reply.PayloadJson);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

