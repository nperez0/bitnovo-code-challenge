using Bitnovo.Customers.Application.Services;
using Bitnovo.Customers.Infrastructure.Data;
using Bitnovo.Customers.Infrastructure.External;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bitnovo.Customers.Api
{
    public class Startup : Bitnovo.Infrastructure.StartupBase
    {
        public override string ServiceName => "Customers";

        public Startup(IConfiguration configuration)
            : base(configuration)
        {
            
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("Banking", c => c.BaseAddress = new Uri(Configuration.GetValue<string>("banking:baseUrl")))
                    .SetHandlerLifetime(TimeSpan.FromMinutes(1));

            base.ConfigureServices(services);

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<Context>(options =>
                {
                    options.UseNpgsql(Configuration["ConnectionString"]);
                });

            services.AddTransient<ICustomersAppService, CustomersAppService>();

            services.AddTransient<ICustomerRepository, CustomerRespository>();

            services.AddTransient<IBankAccountsClient, BankAccountsClient>();

            services.AddCors();
        }
    }
}
