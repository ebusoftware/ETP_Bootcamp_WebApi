using Application_CampFinalProject.Abstractions.Token;
using Infrastructure_CampFinalProject.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_CampFinalProject
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
