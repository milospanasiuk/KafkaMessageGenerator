using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderKafkaMessageGenerator.Business;
using OrderKafkaMessageGenerator.ConfigurationOptions;
using OrderKafkaMessageGenerator.Helpers;
using OrderKafkaMessageGenerator.Interfaces.Business;
using OrderKafkaMessageGenerator.Interfaces.Helpers;
using OrderKafkaMessageGenerator.Repositories;

namespace OrderKafkaMessageGenerator
{
    public static class StartupServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

            services.AddDbContextPool<OrdersContext>(options => options.UseNpgsql(appSettings.DBConnectionString, Npgsql =>
            {

            }));

            services.AddSingleton<IRandomStringGenerator, RandomStringGenerator>();

            services
                .AddScoped<IKafkaMessageGeneratorBusiness, KafkaMessageGeneratorBusiness>();

            return services;
        }
    }
}
