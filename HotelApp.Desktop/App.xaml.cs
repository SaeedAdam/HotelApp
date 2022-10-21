using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HotelAppLibrary.Data;
using HotelAppLibrary.Databases;

namespace HotelApp.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            services.AddTransient<MainWindow>();
            services.AddTransient<CheckInForm>();
            services.AddTransient<ISqlDataAccess, SqlDataAccess>();
            services.AddTransient<ISqliteDataAccess, SqliteDataAccess>();


            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();

            string dbChoice = config.GetValue<string>("DatabaseChoice").ToLower();
            if (dbChoice == "sql")
            {
                services.AddTransient<IDatabaseData, SqlData>();
            }
            else if (dbChoice == "sqlite")
            {
                services.AddTransient<IDatabaseData, SqliteData>();
            }
            else
            {
                // Fallback / Default Value
                services.AddTransient<IDatabaseData, SqlData>();
            }

            services.AddSingleton(config);

            ServiceProvider = services.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetService<MainWindow>();

            mainWindow.Show();
        }
    }
}
