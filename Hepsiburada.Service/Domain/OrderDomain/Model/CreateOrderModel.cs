using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Service.Domain.OrderDomain.Model
{
    public class CreateOrderModel
    {
        public class Request {
            public string ProductCode { get; set; }
            public int Quantity { get; set; }
        };
        public class Response { };
    }
}
