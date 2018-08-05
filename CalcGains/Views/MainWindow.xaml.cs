using CalcGains.ViewModels;
using CalcGains.Views;
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

namespace CalcGains
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button_Click(null, null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new OverviewView()); // musze sprawdzic jak przelaczac miedzy oknami, na pewno potrzebuje applicationContext, ale jeszcze musze
            // miec jakies gowno ktore bedzie mi rozdawac widoki, zeby ich nie tworzyc Bog wie ile.
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new RedTestPage());
        }
    }
}
