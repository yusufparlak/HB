using Hepsiburada.Service.Base.Service;
using Hepsiburada.Service.Domain.CampaignDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Service.Domain.CampaignDomain
{
    public interface ICampaignService:IBaseService
    {
        void CreateCampaign(CreateCampaignModel.Request request);
        void CampaignInfo(CampaignInfoModel.Request request);
        void IncreaseTime(IncreaseTimeModel.Request request);
    }
}
