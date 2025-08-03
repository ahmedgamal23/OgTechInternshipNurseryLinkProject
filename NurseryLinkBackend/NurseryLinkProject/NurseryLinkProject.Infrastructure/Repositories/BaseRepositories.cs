using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Application.Interfaces;
using NurseryLinkProject.Domain.Data;
using NurseryLinkProject.Shared.BaseModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NurseryLinkProject.Infrastructure.Repositories
{
    public class BaseRepositories<T> : IBaseRepository<T> where T : class
    {
        private AppDbContext _context;
        private DbSet<T> _dbSet { get; set; }
        public BaseRepositories(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async ValueTask<BaseReturnModel<T>> GetAllAsync(int pageNumber = 1, int pageSize = 10, Func<IQueryable<T>, IQueryable<T>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;
            int totalCount = await query.CountAsync();
            if (include != null)
                query = include(query);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return new BaseReturnModel<T>
            {
                pageSize = pageSize,
                pageNumber = pageNumber,
                totalCount = totalCount,
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                DataList = await query.ToListAsync()
            };
        }

        public async ValueTask<BaseReturnModel<T>> GetByAsync(Expression<Func<T, bool>> filter, int pageNumber = 1, int pageSize = 10, Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query = _dbSet;
            int totalCount = await query.CountAsync();
            if (include != null)
                query = include(query);

            query = query.Where(filter);
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return new BaseReturnModel<T>
            {
                pageSize = pageSize,
                pageNumber = pageNumber,
                totalCount = totalCount,
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                DataList = await query.ToListAsync()
            };
        }

        public async ValueTask<BaseReturnModel<T>> GetByIdAsync(int id)
        {
            return new BaseReturnModel<T>
            {
                Data = await _dbSet.FindAsync(id),
            };
        }

        public async ValueTask<BaseReturnModel<T>> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new BaseReturnModel<T>
            {
                Data = entity
            };
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = _dbSet.Find(id);
                if (entity == null)
                    return false;
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
