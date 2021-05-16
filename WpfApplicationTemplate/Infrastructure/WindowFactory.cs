using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplicationTemplate.Infrastructure
{
    public class WindowFactory : IWindowFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public WindowFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public T CreateWindow<T>() where T : Window => (T)_serviceProvider.GetRequiredService(typeof(T));
    }
}
