using Hepsiburada.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Service.Base.Service
{
    public class BaseService : IBaseService
    {
        protected DataContext dataContext;
        public BaseService()
        {
            dataContext = DataContext.Context;
        }
    }
}
