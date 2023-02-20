using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Pryanik.Data;
using Pryanik.Repositories.ItemsRepo;
using Pryanik.Repositories.OrdersRepo;
using Pryanik.Services.ItemServices;
using Pryanik.Services.OrderService;
using System.Reflection;

namespace Pryanik
{
    public static class ServiceExtensions
    {
        public static void ConfigureNpgsqlContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
                            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureUseInMemoryDatabase(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
                            opt.UseInMemoryDatabase("PryanikDb"));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IItemsRepository, ItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<IOrderService, OrderService>();
        }
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            Assembly appAssembly = typeof(Program).Assembly;
            typeAdapterConfig.Scan(appAssembly);

            services.AddSingleton(typeAdapterConfig);
            services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}
