using HotelAppLibrary.Data;
using HotelAppLibrary.Databases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace HotelApp.Desktop
{
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = Host.CreateApplicationBuilder();

            // builder.ConfigureServices((context, services) is no longer available in .NET 6+

            builder.Services.AddTransient<IDatabaseData, SqlData>();
            builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
            builder.Services.AddSingleton<MainWindow>();

            AppHost = builder.Build();
            AppHost.Start();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);

            //mainWindow.Show()   Displays the main window
            //base.OnStartup(e)   Starts the WPF app lifecycle and message loop
            //Application.Run()   Implicitly called when App.xaml launches
        }
    }
}