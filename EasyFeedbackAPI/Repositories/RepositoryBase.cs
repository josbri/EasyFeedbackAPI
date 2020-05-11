using EasyFeedbackAPI.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public class RepositoryBase<T> :  IRepositoryBase<T> where T : class
    {

        protected readonly EasyFeedbackContext _context;

        public RepositoryBase(EasyFeedbackContext context)
        {
            _context = context;
        }


        public async Task<T> FindFirstByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> FindListByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }


        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}
