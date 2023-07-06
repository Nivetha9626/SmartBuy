using Microsoft.Extensions.DependencyInjection;
using SmartBuy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuy.Service
{
    public static class ServicesDI
    {
        public static IServiceCollection AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, ProductService>();

            return services;
        }
    }
}
