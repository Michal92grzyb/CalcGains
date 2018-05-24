using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcGainsApi.ViewModels;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;

namespace CalcGainsViewModel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        public ICommand Click { get; set; }

        public MainWindowViewModel()
        {
            Click = new RelayCommand(Clickc);
        }

        private void Clickc()
        {
            Debug.WriteLine("dziala");
        }

        public static void Main(string[] args)
        {

        }
    }
}
