using Hepsiburada.Service.Domain.ProductDomain;
using Hepsiburada.Service.Domain.OrderDomain;
using Hepsiburada.Service.Domain.CampaignDomain;
using Hepsiburada.Service.Domain.ProductDomain.Model;
using Hepsiburada.Service.Domain.CampaignDomain.Model;
using Hepsiburada.Service.Domain.OrderDomain.Model;

namespace Hepsiburada.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string productName = "P1";
            string campaignName = "C1";
            var productService = new ProductService();
            var orderService = new OrderService();
            var campaignService = new CampaignService();

            productService.CreateProduct(new CreateProductModel.Request { ProductCode = productName, Price = 100, Stock = 1000 });
            campaignService.CreateCampaign(new CreateCampaignModel.Request { Name = campaignName, ProductCode = productName, Duration = 5, PriceManipulationLimit = 20, TargetSalesCount = 100 });
            productService.ProductInfo(new ProductInfoModel.Request { ProductCode = productName });
            campaignService.IncreaseTime(new IncreaseTimeModel.Request { Hour = 1 });
            productService.ProductInfo(new ProductInfoModel.Request { ProductCode = productName });
            campaignService.IncreaseTime(new IncreaseTimeModel.Request { Hour = 1 });
            productService.ProductInfo(new ProductInfoModel.Request { ProductCode = productName });
            campaignService.IncreaseTime(new IncreaseTimeModel.Request { Hour = 1 });
            productService.ProductInfo(new ProductInfoModel.Request { ProductCode = productName });
            orderService.CreateOrder(new CreateOrderModel.Request { ProductCode = productName, Quantity = 1001 });
            campaignService.IncreaseTime(new IncreaseTimeModel.Request { Hour = 1 });
            productService.ProductInfo(new ProductInfoModel.Request { ProductCode = productName });
            campaignService.IncreaseTime(new IncreaseTimeModel.Request { Hour = 2 });
            productService.ProductInfo(new ProductInfoModel.Request { ProductCode = productName });
            campaignService.CampaignInfo(new CampaignInfoModel.Request { CampaignName = campaignName });
        }
    }
}