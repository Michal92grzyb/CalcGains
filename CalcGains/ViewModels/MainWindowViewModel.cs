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

        private bool _addProductVisibility;

        public bool AddProductVisibility
        {
            get { return _addProductVisibility; }
            set
            {
                _addProductVisibility = value;
                RaisePropertyChanged(nameof(AddProductVisibility));
            }
        }

        public MainWindowViewModel()
        {
            command1 = new RelayCommand(command1c);
            AddProductVisibility = false;
        }

        private void command1c()
        {
            AddProductVisibility = !AddProductVisibility;
        }
    }
}
