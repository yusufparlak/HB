
namespace Hepsiburada.Data.Domain
{
    public class Order
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal CurrentUnitPrice { get; set; }
    }
}