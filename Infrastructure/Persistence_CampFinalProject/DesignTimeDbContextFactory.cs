
using API.CampFinalProjectAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence_CampFinalProject
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShoppingListDbContext>
    {
        public ShoppingListDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ShoppingListDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
