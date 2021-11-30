using Hepsiburada.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Data.Context
{
    public class DataContext
    {
        public DataContext()
        {
            Orders = new List<Order>();
            Campaigns = new List<Campaign>();
            Products = new List<Product>();
        }
        #region Db Sets
        public List<Order> Orders { get; set; }
        public List<Campaign> Campaigns { get; set; }
        public List<Product> Products { get; set; }
        #endregion

        public static DataContext Context => GetContext();
        private static DataContext context { get; set; }
        private static readonly object forLock = new object();
        private static DataContext GetContext()
        {
            lock (forLock)
            {
                if (context == null)
                    context = new DataContext(); return context;
            }
        }
    }
}
