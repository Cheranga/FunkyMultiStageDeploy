using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using FunkyDeploy.Services.Abstractions;
using FunkyDeploy.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace FunkyDeploy.Services
{
    public static class Bootstrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
        }
    }
}
