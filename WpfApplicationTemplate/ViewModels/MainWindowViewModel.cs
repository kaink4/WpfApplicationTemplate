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

namespace WpfApplicationTemplate.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly ISampleService _sampleService;
        private readonly IOptions<AppSettings> _options;

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


        public MainWindowViewModel(ISampleService sampleService, IOptions<AppSettings> options)
        {
            _sampleService = sampleService;
            _options = options;
        }

        public ICommand GetActualDateCommand => new RelayCommand(_ => SomeText = _sampleService.GetCurrentDate());
        public ICommand GetSettingsCommand => new RelayCommand(_ =>
        {
            var settings = _options.Value;
            SomeText = JsonSerializer.Serialize(settings);
        });

        public ICommand GetProductsCommand => new RelayCommand(_ => SomeText = _sampleService.GetProducts());
    }
}
