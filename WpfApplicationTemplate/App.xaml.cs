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
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Configuration = ConfigurationFactory.GetConfiguration();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            using var context = ServiceProvider.GetService<IDbContextFactory<SampleDbContext>>().CreateDbContext();
            context.Database.Migrate();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
            services.AddDbContextFactory<SampleDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("SampleDbContext")));

            services.Scan(s => s.FromCallingAssembly()
                .AddClasses(c => c.AssignableToAny(typeof(Window), typeof(ViewModelBase)))
                .AsSelf()
                .WithTransientLifetime());

            services.AddTransient<IWindowFactory, WindowFactory>();
            services.AddTransient<ISampleService, SampleService>();
        }
    }
}
