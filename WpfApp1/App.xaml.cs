using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private readonly ServiceProvider _serviceProvider;
        //public App()
        //{
        //    IServiceCollection services = new ServiceCollection();
        //    services.AddSingleton<MainWindow>(provider => new MainWindow
        //    {
        //        DataContext = provider.GetRequiredService<MainViewModel>() 
        //    });
        //    services.AddSingleton<MainViewModel>();
        //    services.AddSingleton<HomeViewModel>();
        //    services.AddSingleton<GameViewModel>();

        //    _serviceProvider = services.BuildServiceProvider();
        //}

        protected override void OnStartup(StartupEventArgs e)
        {
            //var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            base.OnStartup(e);
        }
    }
}
