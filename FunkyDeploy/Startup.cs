using System;
using System.Collections.Generic;
using System.Text;
using FunkyDeploy;
using FunkyDeploy.Services;
using FunkyDeploy.Services.Abstractions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly:FunctionsStartup(typeof(Startup))]
namespace FunkyDeploy
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            RegisterServices(services);
            services.RegisterServices();
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDtoService, DtoService>();
        }
    }
}
