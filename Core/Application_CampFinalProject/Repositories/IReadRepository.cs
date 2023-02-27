using Domain_CampFinalProject.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Repositories
{
    public interface IReadRepository<T>:IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll(bool tracking = true);
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        Task<T> GetByIdAsync(int id);
    }
}
