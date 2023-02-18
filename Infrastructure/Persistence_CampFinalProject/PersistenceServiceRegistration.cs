using API.CampFinalProjectAPI.Contexts;
using Application_CampFinalProject.Repositories;
using Domain_CampFinalProject.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence_CampFinalProject.Repositories;
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
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
            }).AddEntityFrameworkStores<ShoppingListDbContext>();

            services.AddDbContext<ShoppingListDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();

            services.AddSingleton<IBrandWriteRepository, BrandWriteRepository>();
            services.AddSingleton<IBrandReadRepository, BrandReadRepository>();

            services.AddSingleton<ICategoryReadRepository, CategoryReadRepository>();
            services.AddSingleton<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddSingleton<IShoppingListWriteRepository, ShoppingListWriteRepository>();
            services.AddSingleton<IShoppingListReadRepository, ShoppingListReadRepository>();

            services.AddSingleton<IShoppingListItemReadRepository, ShoppingListItemReadRepository>();
            services.AddSingleton<IShoppingListItemWriteRepository, ShoppingListItemWriteRepository>();


        }
    }
}
