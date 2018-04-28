using DotNetAPISandBox.Data.Interface;
using DotNetAPISandBox.Data.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAPISandBox.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext databaseContext;

        public UnitOfWork(IDatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IBaseRepository Repository()
        {
            return new BaseRepository(databaseContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await databaseContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            databaseContext.Dispose();
        }

        public Task CommitAsync()
        {
            return databaseContext.SaveChangesAsync();
        }
    }
}
