using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Grpc.Net.Client;
using gRPCServerProtos;

namespace GrpcUsingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        [HttpGet]
        public async Task<ProductModel> SelectDepartment()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7033");
            var client = new Product.ProductClient(channel);
            var product = new GetProductDetail
            {
                ProductId = 1
            };

            var serverReply = await client.GetProductInformationAsync(product);
            //Console.WriteLine($"{serverReply.ProductName} | {serverReply.ProductPrice} | {serverReply.ProductPrice} | {serverReply.ProductStock}");
            //Console.ReadLine();
            return serverReply;
        }
    }

}
