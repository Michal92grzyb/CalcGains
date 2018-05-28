using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CalcGains.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand command1 { get; private set; }

        private bool _vis;

        public bool Vis
        {
            get { return _vis; }
            set
            {
                _vis = value;
                RaisePropertyChanged(nameof(Vis));
            }
        }

        public MainWindowViewModel()
        {
            command1 = new RelayCommand(command1c);
            Vis = false;
        }

        private void command1c()
        {
            Vis = !Vis;
        }
    }
}
