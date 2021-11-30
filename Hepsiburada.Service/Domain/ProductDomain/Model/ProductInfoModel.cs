using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Service.Domain.ProductDomain.Model
{
    public class ProductInfoModel
    {
        public class Request { public string ProductCode { get; set; } }
        public class Response
        {
            public decimal Price { get; internal set; }
            public int Stock { get; internal set; }
        }
    }
}
