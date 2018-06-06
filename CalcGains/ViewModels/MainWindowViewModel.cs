using CalcGains.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CalcGains.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand AddProductCommand { get; private set; }
        public ICommand AddProductDoneCommand { get; private set; }

        private string _productName;
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                RaisePropertyChanged();
            }
        }

        private string _calories;
        public string Calories
        {
            get
            {
                return _calories;
            }
            set
            {
                _calories = value;
                RaisePropertyChanged();
            }
        }

        private string _protein;
        public string Protein
        {
            get
            {
                return _protein;
            }
            set
            {
                _protein = value;
                RaisePropertyChanged();
            }
        }

        private string _fat;
        public string Fat
        {
            get
            {
                return _fat;
            }
            set
            {
                _fat = value;
                RaisePropertyChanged();
            }
        }
        private string _carbs;
        public string Carbs
        {
            get
            {
                return _carbs;
            }
            set
            {
                _carbs = value;
                RaisePropertyChanged();
            }
        }

        private List<Product> _productsList;
        public ObservableCollection<Product> Products
        {
            get
            {
                return new ObservableCollection<Product>(_productsList);
            }
            set
            {
                _productsList = value.ToList<Product>();
                RaisePropertyChanged();
            }
        }

        private bool _addProductVisibility;

        public bool AddProductVisibility
        {
            get { return _addProductVisibility; }
            set
            {
                _addProductVisibility = value;
                RaisePropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            AddProductCommand = new RelayCommand(ShowAddProductBar);
            AddProductDoneCommand = new RelayCommand(AddProduct);
            AddProductVisibility = false;
            _productsList = new List<Product>();

        }

        private void ShowAddProductBar()
        {
            AddProductVisibility = !AddProductVisibility;
        }

        private void AddProduct()
        {
            try
            {
                double kcal = double.Parse(Calories);
                double prot = double.Parse(Protein);
                double fatty = double.Parse(Fat);
                double carb = double.Parse(Carbs);
                Product newProduct = new Product(ProductName, kcal, prot, fatty, carb);
                _productsList.Add(newProduct);
                Products = new ObservableCollection<Product>(_productsList);
                AddProductVisibility = false;
                Calories = Protein = Fat = Carbs = ProductName = string.Empty;
                
            }
            catch
            {
                MessageBox.Show("wrong data", "Error");
            }
        }
    }
}
