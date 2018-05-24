using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalcGains.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
       public ICommand command1;

       public MainWindowViewModel()
        {
            command1 = new RelayCommand(command1c);
        }

        private void command1c()
        {
            Console.WriteLine("dziala");
        }
    }
}
