using Application_CampFinalProject.Abstractions;
using Application_CampFinalProject.Abstractions.Storage;
using Application_CampFinalProject.Abstractions.Token;
using Application_CampFinalProject.Services.Configurations;
using Infrastructure_CampFinalProject.Configurations;
using Infrastructure_CampFinalProject.Enums;
using Infrastructure_CampFinalProject.Services.Storage;
using Infrastructure_CampFinalProject.Services.Storage.Azure;
using Infrastructure_CampFinalProject.Services.Storage.Local;
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
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>(); 
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local: //Storage tipi eğer lokal ise IOC de IStorage'a karşılık LocalStorage'ı ver.
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();//Storage Belirtilmemişse, default olarak local yap.
                    break;
            }
        }
    }
    }

