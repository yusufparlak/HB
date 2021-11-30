using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Service.Domain.ProductDomain.Model
{
    public class CreateProductModel
    {
        public class Request { 
            public string ProductCode { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }
        public class Response { }
    }
}
