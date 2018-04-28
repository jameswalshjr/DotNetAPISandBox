using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DotNetAPISandBox.Data.Interface;
using DotNetAPISandBox.Data.Resource;

namespace DotNetAPISandBox.Data.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IDatabaseContext _dbContext;
        public BaseRepository(IDatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await _dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync<T>() where T : class
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public T Add<T>(T dto) where T : class
        {
           return _dbContext.Set<T>().Add(dto);
        }

        public void Update<T>(T dto) where T : class
        {
            _dbContext.Entry(dto).State = EntityState.Modified;
        }

       
    }
}
