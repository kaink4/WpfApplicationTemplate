using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplicationTemplate.Infrastructure;
using WpfApplicationTemplate.ViewModels;

namespace WpfApplicationTemplate.Views
{
    /// <summary>
    /// Interaction logic for SampleWindow.xaml
    /// </summary>
    public partial class SampleWindow : Window, ICloseable
    {
        public SampleWindow(SampleWindowViewModel sampleWindowViewModel)
        {
            InitializeComponent();
            DataContext = sampleWindowViewModel;
        }
    }
}
