using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetAPISandBox.Data.Interface
{
    public interface IBaseRepository
    {
        Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<IEnumerable<T>> FindAsync<T>() where T : class;

       Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class;

        T Add<T>(T dto) where T : class;
        T Update<T>(T dto) where T : class;

    }
}
