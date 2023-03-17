using API.CampFinalProjectAPI.Contexts;
using Application_CampFinalProject.Repositories;
using Application_CampFinalProject.Services;
using Application_CampFinalProject.Services.Authentications;
using Domain_CampFinalProject.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence_CampFinalProject.Repositories;
using Persistence_CampFinalProject.Services;
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
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
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

            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();

            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();




        }
    }
}
