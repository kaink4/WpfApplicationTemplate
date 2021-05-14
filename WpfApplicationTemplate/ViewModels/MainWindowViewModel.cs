using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplicationTemplate.Infrastructure;
using WpfApplicationTemplate.Services;
using WpfApplicationTemplate.Views;

namespace WpfApplicationTemplate.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ISampleService _sampleService;
        private readonly IOptions<AppSettings> _options;
        private readonly IWindowFactory _windowFactory;
        private string _someText;
        public string SomeText
        {
            get => _someText;
            set
            {
                _someText = value;
                OnPropertyChanged(nameof(SomeText));
            }
        }


        public MainWindowViewModel(ISampleService sampleService, IOptions<AppSettings> options, IWindowFactory windowFactory)
        {
            _sampleService = sampleService;
            _options = options;
            _windowFactory = windowFactory;
        }

        public ICommand GetActualDateCommand => new RelayCommand(_ => SomeText = _sampleService.GetCurrentDate());
        public ICommand GetSettingsCommand => new RelayCommand(_ =>
        {
            var settings = _options.Value;
            SomeText = JsonSerializer.Serialize(settings);
        });

        public ICommand GetProductsCommand => new RelayCommand(_ => SomeText = _sampleService.GetProducts());

        public ICommand ShowSampleWindowCommand => new RelayCommand<string>(mode =>
        {
            var sampleWindow = _windowFactory.CreateWindow<SampleWindow>();
            if (mode == "modal")
            {
                sampleWindow.ShowDialog();
            }
            else
            {
                sampleWindow.Show();
            }
        });
    }
}
