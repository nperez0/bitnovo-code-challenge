using Bitnovo.Banking.Application.Services;
using Bitnovo.Banking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bitnovo.Banking.Api
{
    public class Startup : Bitnovo.Infrastructure.StartupBase
    {
        public override string ServiceName => "Banking";

        public Startup(IConfiguration configuration)
            : base(configuration)
        {
            
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<Context>(options =>
                {
                    options.UseNpgsql(Configuration["ConnectionString"]);
                });

            services.AddTransient<IAccountsAppService, AccountsAppService>();

            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddCors();
        }
    }
}
