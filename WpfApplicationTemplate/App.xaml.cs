using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApplicationTemplate.DataAccess;
using WpfApplicationTemplate.Infrastructure;
using WpfApplicationTemplate.Services;
using WpfApplicationTemplate.ViewModels;

namespace WpfApplicationTemplate
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            using var context = serviceProvider.GetRequiredService<IDbContextFactory<SampleDbContext>>().CreateDbContext();
            context.Database.Migrate();

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = ConfigurationFactory.GetConfiguration(); 

            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddDbContextFactory<SampleDbContext>(options => options.UseSqlite(configuration.GetConnectionString("SampleDbContext")));

            services.Scan(s => s.FromCallingAssembly()
                .AddClasses(c => c.AssignableToAny(typeof(Window), typeof(ViewModelBase)))
                .AsSelf()
                .WithTransientLifetime());

            services.AddTransient<IWindowFactory, WindowFactory>();
            services.AddTransient<ISampleService, SampleService>();
        }
    }
}
