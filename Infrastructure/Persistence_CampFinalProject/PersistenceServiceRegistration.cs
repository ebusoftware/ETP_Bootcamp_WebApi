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

            //Add DB CONTEXT
            services.AddDbContext<ShoppingListDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            //Add application services.
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();
            services.AddScoped<IBrandReadRepository, BrandReadRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IShoppingListWriteRepository, ShoppingListWriteRepository>();
            services.AddScoped<IShoppingListReadRepository, ShoppingListReadRepository>();

            services.AddScoped<IShoppingListItemReadRepository, ShoppingListItemReadRepository>();
            services.AddScoped<IShoppingListItemWriteRepository, ShoppingListItemWriteRepository>();
            


        }
    }
}
