using Hepsiburada.Service.Base.Service;
using Hepsiburada.Service.Domain.ProductDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Service.Domain.ProductDomain
{
    public interface IProductService : IBaseService
    {
        void CreateProduct(CreateProductModel.Request request);
        ProductInfoModel.Response ProductInfo(ProductInfoModel.Request request);
    }
}