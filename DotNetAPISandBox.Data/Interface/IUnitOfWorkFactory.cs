using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAPISandBox.Data.Interface
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
