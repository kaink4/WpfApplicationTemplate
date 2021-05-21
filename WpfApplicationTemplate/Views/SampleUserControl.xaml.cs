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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplicationTemplate.ViewModels;

namespace WpfApplicationTemplate.Views
{
    /// <summary>
    /// Interaction logic for SampleUserControl.xaml
    /// </summary>
    public partial class SampleUserControl : UserControl 
    {
        public SampleUserControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
            "Text", typeof(string),
            typeof(SampleUserControl)
            );

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
