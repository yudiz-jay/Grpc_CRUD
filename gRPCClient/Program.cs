// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using gRPCServerProtos;

var channel = GrpcChannel.ForAddress("https://localhost:7033");
var client = new Product.ProductClient(channel);
var product = new GetProductDetail
{
    ProductId = 1
};

var serverReply = await client.GetProductInformationAsync(product);
Console.WriteLine($"{serverReply.ProductName} | {serverReply.ProductPrice} | {serverReply.ProductPrice} | {serverReply.ProductStock}");
Console.ReadLine();
