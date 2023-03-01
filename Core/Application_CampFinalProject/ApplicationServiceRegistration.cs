﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ApplicationServiceRegistration));
            collection.AddAutoMapper(Assembly.GetExecutingAssembly());

        }

    }
}
