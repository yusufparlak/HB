using Hepsiburada.Service.Domain.CampaignDomain.Model;
using Hepsiburada.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hepsiburada.Service.Base.Service;
using Hepsiburada.Service.Base.Constant;

namespace Hepsiburada.Service.Domain.CampaignDomain
{
    public class CampaignService : BaseService, ICampaignService
    {
        public void CampaignInfo(CampaignInfoModel.Request request)
        {
            Console.WriteLine($"get_campaign_info {request.CampaignName}");
            var campaign = dataContext.Campaigns.FirstOrDefault(m => m.Name == request.CampaignName);
            if (campaign == null) Console.WriteLine("Campaign not found!");
            else
            {
                var orders = dataContext.Orders.Where(m => m.ProductCode == campaign.ProductCode);
                var totalSaleQuantity = orders.Sum(m => m.Quantity);
                var totalSaleIncome = orders.Sum(m => m.Quantity * m.CurrentUnitPrice);
                var averageItemPrice = totalSaleQuantity == 0 ? 0 : (totalSaleIncome / totalSaleQuantity);
                var turnover = totalSaleQuantity * averageItemPrice;
                Console.WriteLine($"Campaign {campaign.Name} info; Status {campaign.Status.ToString()}, Target Sales {campaign.TargetSalesCount}, TotalSales {totalSaleQuantity}, Turnover {turnover}, Average Item Price {averageItemPrice}");
            }
        }

        public void CreateCampaign(CreateCampaignModel.Request request)
        {
            Console.WriteLine($"create_campaign {request.Name} {request.ProductCode} {request.Duration} {request.PriceManipulationLimit} {request.TargetSalesCount}");
            var campaign = new Campaign { Name = request.Name, Status = CampaignStatuses.Active, ProductCode = request.ProductCode, Duration = request.Duration, PriceManipulationLimit = request.PriceManipulationLimit, TargetSalesCount = request.TargetSalesCount };
            dataContext.Campaigns.Add(campaign);
            Console.WriteLine($"Campaign created; name {campaign.Name}, product {campaign.ProductCode}, duration {campaign.Duration}, limit {campaign.PriceManipulationLimit}, target sales count {campaign.TargetSalesCount}");
        }

        public void IncreaseTime(IncreaseTimeModel.Request request)
        {
            Console.WriteLine($"increase_time {request.Hour}");
            TimeConstant.Increase(request.Hour);
            var time = DateTime.Today.AddHours(TimeConstant.Time);
            var endedCampaigns = dataContext.Campaigns.Where(m => m.Duration < TimeConstant.Time && m.Status == CampaignStatuses.Active);//Süresi bitmiş kampanyalar
            foreach (var item in endedCampaigns)
            {
                item.Status = CampaignStatuses.Ended;
            }
            Console.WriteLine($"Time is {time.ToString("t")}");
        }
    }
}