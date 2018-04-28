using DotNetAPISandBox.Data.Interface;
using DotNetAPISandBox.Data.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAPISandBox.Data.Repository
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
       public IUnitOfWork Create()
        {
            return new UnitOfWork(new BillingContext());
        }
    }
}
