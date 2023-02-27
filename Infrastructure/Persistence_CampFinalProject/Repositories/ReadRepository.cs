using API.CampFinalProjectAPI.Contexts;
using Application_CampFinalProject.Repositories;
using Domain_CampFinalProject.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence_CampFinalProject.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : Entity
    {
        private readonly ShoppingListDbContext _context;

        public ReadRepository(ShoppingListDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //gerekli entity'i almak için Set methodunu kullandık. 

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            //eğer herhangi bir tracking istenmiyorsa, AsNoTrack fonksiyonu ile datanın track edilmesini engelliyoruz.
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByIdAsync(int id)
            => await Table.FirstOrDefaultAsync(data => data.Id == id);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);
    }
}
