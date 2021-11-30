using Hepsiburada.Data.Domain;
using Hepsiburada.Service.Base.Service;
using Hepsiburada.Service.Domain.OrderDomain.Model;
using Hepsiburada.Service.Domain.ProductDomain;
using System;
using System.Linq;

namespace Hepsiburada.Service.Domain.OrderDomain
{
    public class OrderService : BaseService, IOrderService
    {
        public void CreateOrder(CreateOrderModel.Request request)
        {
            Console.WriteLine($"create_order {request.ProductCode} {request.Quantity}");
            ProductService productService = new ProductService();
            var product = productService.ProductInfo(new ProductDomain.Model.ProductInfoModel.Request { ProductCode = request.ProductCode });
            var saledProductCount = dataContext.Orders.Where(m => m.ProductCode == request.ProductCode).Sum(m => m.Quantity);
            if (product.Stock - saledProductCount - request.Quantity < 0) Console.WriteLine("Insufficient stock!");
            else
            {
                var order = new Order { ProductCode = request.ProductCode, Quantity = request.Quantity, CurrentUnitPrice = product.Price };
                dataContext.Orders.Add(order);
                Console.WriteLine($"Order created; product {order.ProductCode}, quantity {order.Quantity}");
            }
        }
    }
}