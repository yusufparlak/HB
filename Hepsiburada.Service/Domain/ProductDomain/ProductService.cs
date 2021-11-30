using Hepsiburada.Service.Domain.ProductDomain.Model;
using Hepsiburada.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hepsiburada.Service.Base.Service;
using Hepsiburada.Service.Base.Constant;

namespace Hepsiburada.Service.Domain.ProductDomain
{
    public class ProductService : BaseService, IProductService
    {
        public void CreateProduct(CreateProductModel.Request request)
        {
            Console.WriteLine($"create_product {request.ProductCode} {request.Price} {request.Stock}");
            var product = new Product
            {
                Price = request.Price,
                ProductCode = request.ProductCode,
                Stock = request.Stock,
            };
            dataContext.Products.Add(product);
            Console.WriteLine($"Product created; code {product.ProductCode}, price {product.Price}, stock {product.Stock}");
        }

        public ProductInfoModel.Response ProductInfo(ProductInfoModel.Request request)
        {
            Console.WriteLine($"get_product_info {request.ProductCode}");
            var response = new ProductInfoModel.Response();
            var product = dataContext.Products.FirstOrDefault(m => m.ProductCode == request.ProductCode);
            if (product == null) Console.WriteLine("Product not found!");
            else
            {
                decimal discount = 0;
                int orderProductQuantity = dataContext.Orders.Where(m => m.ProductCode == product.ProductCode).Sum(m => m.Quantity); ;
                var campaign = dataContext.Campaigns.FirstOrDefault(m => m.ProductCode == product.ProductCode && m.Status == CampaignStatuses.Active && m.Duration > TimeConstant.Time);
                if (campaign != null)
                {
                    discount = (((product.Price * campaign.PriceManipulationLimit) / 100) / campaign.Duration) * TimeConstant.Time;
                }
                response.Price = product.Price - discount;
                response.Stock = product.Stock - orderProductQuantity;
                Console.WriteLine($"Product {product.ProductCode} Info: price {response.Price}, stock {response.Stock}");
            }
            return response;
        }
    }
}