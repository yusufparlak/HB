using Hepsiburada.Service.Base.Service;
using Hepsiburada.Service.Domain.OrderDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Service.Domain.OrderDomain
{
    public interface IOrderService: IBaseService
    {
        void CreateOrder(CreateOrderModel.Request request);
    }
}
