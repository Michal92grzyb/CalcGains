using CalcGains.Model;
using CalcGains.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcGains.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        #region Products props
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

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Meal props

        private List<Product> _productsListMeal;
        public ObservableCollection<Product> ProductsMeal
        {
            get
            {
                return new ObservableCollection<Product>(_productsListMeal);
            }
            set
            {
                _productsListMeal = value.ToList<Product>();
                RaisePropertyChanged();
            }
        }

        private string _productNameMeal;
        public string ProductNameMeal
        {
            get
            {
                return _productNameMeal;
            }
            set
            {
                _productNameMeal = value;
                RaisePropertyChanged();
            }
        }

        private string _caloriesMeal;
        public string CaloriesMeal
        {
            get
            {
                return _caloriesMeal;
            }
            set
            {
                _caloriesMeal = value;
                RaisePropertyChanged();
            }
        }

        private string _proteinMeal;
        public string ProteinMeal
        {
            get
            {
                return _proteinMeal;
            }
            set
            {
                _proteinMeal = value;
                RaisePropertyChanged();
            }
        }

        private string _fatMeal;
        public string FatMeal
        {
            get
            {
                return _fatMeal;
            }
            set
            {
                _fat = value;
                RaisePropertyChanged();
            }
        }
        private string _carbsMeal;
        public string CarbsMeal
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

        private Product _selectedProductMeal;
        public Product SelectedProductMeal
        {
            get
            {
                return _selectedProductMeal;
            }
            set
            {
                _selectedProductMeal = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public OverviewViewModel()
        {
            _productsList = ProductsSaver.LoadFromCsv();
            RaisePropertyChanged();
        }
    }
}
