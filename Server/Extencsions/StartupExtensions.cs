using MySql.Data.MySqlClient;
using Server.Repository;
using Server.Services;
using System.Configuration;

namespace Server.Extensions
{

    public static class StartupExtension
    {
        public static void AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(_ => new MySqlConnection(connectionString));
            services.AddTransient<UserRepository>();          
        }

        public static void AddServices(this IServiceCollection services)
        {

            services.AddTransient<UserService>();          
        }


    }
}