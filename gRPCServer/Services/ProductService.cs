using Grpc.Core;
using gRPCServerProtos;
namespace gRPCServer.Services
{
    public class ProductService : Product.ProductBase
    {
        private readonly ILogger<ProductService> _logger;
        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public override Task<ProductModel> GetProductInformation(GetProductDetail request, ServerCallContext context)
        {
            ProductModel productDetail = new ProductModel();

            if(request.ProductId==1)
            {
                productDetail.ProductName = "Samsung";
                productDetail.ProductDescription = "Smart TV";
                productDetail.ProductPrice = 35000;
                productDetail.ProductStock = 10;
            }
            else if(request.ProductId==2)
            {
                productDetail.ProductName = "LG";
                productDetail.ProductDescription = "OLED TV";
                productDetail.ProductPrice = 350000;
                productDetail.ProductStock = 12;
            }
            else if(request.ProductId==3)
            {
                productDetail.ProductName = "IPhone";
                productDetail.ProductDescription = "SmartPhone";
                productDetail.ProductPrice = 150000;
                productDetail.ProductStock = 9;
            }
            return Task.FromResult(productDetail);
        }
        
    }
}
