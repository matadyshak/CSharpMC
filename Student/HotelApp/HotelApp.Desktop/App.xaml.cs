using HotelAppLibrary.Data;
using HotelAppLibrary.Databases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace HotelApp.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider serviceProvider;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            // Transient - a new instance is provided every time
            services.AddTransient<MainWindow>();
            services.AddTransient<CheckInForm>();
            services.AddTransient<IDatabaseData, SqlData>();
            services.AddTransient<ISqlDataAccess, SqlDataAccess>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();
            //Add as singleton - one instance for the lifetime of the application
            //Adding it to DI container
            services.AddSingleton(config);

            serviceProvider = services.BuildServiceProvider();
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
