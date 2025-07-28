using NurseryLinkProject.Shared.BaseModel;
using System.Linq.Expressions;

namespace NurseryLinkProject.Application.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public ValueTask<BaseReturnModel<T>> GetAllAsync(int pageNumber = 1, int pageSize = 10,
            Func<IQueryable<T>, IQueryable<T>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Expression<Func<T, bool>>? filter = null
            );
        public ValueTask<BaseReturnModel<T>> GetByIdAsync(int id);
        public ValueTask<BaseReturnModel<T>> GetByAsync(Expression<Func<T, bool>> filter,
            int pageNumber = 1, int pageSize = 10, Func<IQueryable<T>, IQueryable<T>>? include = null);

        public ValueTask<BaseReturnModel<T>> AddAsync(T entity);
        public bool Update(T entity);
        public bool Delete(int id);
    }
}

