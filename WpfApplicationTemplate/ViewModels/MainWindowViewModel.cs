using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplicationTemplate.Services;

namespace WpfApplicationTemplate.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ISampleService _sampleService;

        public MainWindowViewModel() { }


        public MainWindowViewModel(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        public ICommand GetCurrentDateCommand => new RelayCommand(a => { });
    }
}
