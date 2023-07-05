using MySql.Data.MySqlClient;
using MusicServer.Repository;
using MusicServer.Services;
using System.Configuration;

namespace MusicServer.Extensions
{

    public static class StartupExtension
    {
        public static void AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(_ => new MySqlConnection(connectionString));
            services.AddTransient<UserRepository>();          
            services.AddTransient<ProductRepository>();
            
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<UserService>();
            services.AddTransient<AccountService>();
            services.AddTransient<ProductService>();
        }


    }
}