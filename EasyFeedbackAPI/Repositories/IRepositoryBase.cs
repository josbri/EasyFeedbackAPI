using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyFeedbackAPI.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> FindFirstByConditionAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindListByConditionAsync(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}