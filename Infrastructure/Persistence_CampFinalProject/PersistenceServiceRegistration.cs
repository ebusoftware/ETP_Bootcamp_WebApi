using API.CampFinalProjectAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence_CampFinalProject
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services) 
        {

            services.AddDbContext<ShoppingListDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

        }
    }
}
