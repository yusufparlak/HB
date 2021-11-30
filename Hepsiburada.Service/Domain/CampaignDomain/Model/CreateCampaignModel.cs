using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Service.Domain.CampaignDomain.Model
{
    public class CreateCampaignModel
    {
        public class Request {
            public string Name { get; set; }
            public string ProductCode { get; set; }
            public int Duration { get; set; }
            public int PriceManipulationLimit { get; set; }
            public int TargetSalesCount { get; set; }
        };
        public class Response { };
    }
}
