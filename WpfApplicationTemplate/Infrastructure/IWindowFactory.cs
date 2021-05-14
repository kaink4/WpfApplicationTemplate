using System.Windows;

namespace WpfApplicationTemplate.Infrastructure
{
    public interface IWindowFactory
    {
        T CreateWindow<T>() where T : Window;
    }
}