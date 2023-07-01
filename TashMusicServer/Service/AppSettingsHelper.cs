using System;

public class AppSettingsHelper
{
    private static string _connectionString;
    public static string ConnectionString => _connectionString ??= GetBuilder().GetConnectionString("MyDatabase");
    //private static string _pathFolder;
    //public static string PathFolder => _pathFolder ??= GetBuilder().GetValue<string>("PathFolder");

    private static IConfigurationRoot GetBuilder()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true)
            .Build();
    }
}
