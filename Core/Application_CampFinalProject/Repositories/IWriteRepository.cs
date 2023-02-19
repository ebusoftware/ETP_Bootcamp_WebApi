using Domain_CampFinalProject.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T:Entity 
    {
        Task<T> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        Task<T> RemoveAsync(T entity);
        bool RemoveRange(List<T> datas);
        bool Update(T model);
        Task<T> UpdateAsync(T entity);
        Task<int> SaveAsync();
    }
}
