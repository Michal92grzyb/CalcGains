using CalcGains.Model;
using CalcGains.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalcGains.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        public ICommand ChangeSearchReesultsCommand { get; set; }
        public ICommand AddToMealCommand { get; set; }
        public ICommand RemoveFromMealCommand { get; set; }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    AddedProducts = new ObservableCollection<Component>();
                    RaisePropertyChanged();
                }
            }
        }

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

        private List<Product> _filteredProducts;
        public ObservableCollection<Product> FilteredProducts
        {
            get
            {
                if (SearchText == string.Empty)
                    return Products;
                return new ObservableCollection<Product>(_productsList.Where(x => x.Name.Contains(SearchText)));
            }
        }

        private List<Component> _addedProducts;
        public ObservableCollection<Component> AddedProducts
        {
            get
            {
                return new ObservableCollection<Component>(_addedProducts);
            }
            set
            {
                _addedProducts = value.ToList<Component>();
                RaisePropertyChanged();
            }
        }

        private string _searchText = string.Empty;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(FilteredProducts));
            }
        }

        public IEnumerable<string> ProductsNames
        {
            get
            {
                var list = Products.Select(x => x.Name).Distinct();
                return list;
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

        private Component _selectedAddedProduct;
        public Component SelectedAddedProduct
        {
            get
            {
                return _selectedAddedProduct;
            }
            set
            {
                _selectedAddedProduct = value;
                RaisePropertyChanged();
            }
        }

        public List<Meal> DailyMealList; // gotta create application context, that feeds all containers.
        #endregion


        public OverviewViewModel()
        {
            _productsList = ProductsSaver.LoadFromCsv();
            _addedProducts = new List<Component>();
            ChangeSearchReesultsCommand = new RelayCommand<string>(ChangeSearchReesults);
            AddToMealCommand = new RelayCommand(AddToMeal);
            RemoveFromMealCommand = new RelayCommand(RemoveFromMeal);
            SelectedDate = DateTime.Now;
            RaisePropertyChanged();
        }

        private void AddToMeal()
        {
            if (SelectedProduct != null)
            {
                List<Component> tempList = new List<Component>(AddedProducts);
                tempList.Add(new Component(SelectedProduct, 0));
                AddedProducts = new ObservableCollection<Component>(tempList); // it sucks.
            }
        }

        private void RemoveFromMeal()
        {
            if (SelectedAddedProduct != null)
            {
                List<Component> tempList = new List<Component>(AddedProducts);
                tempList.Remove(SelectedAddedProduct);
                AddedProducts = new ObservableCollection<Component>(tempList); // it sucks.
            }
        }

        private void ChangeSearchReesults(string newSearch)
        {
            SearchText = newSearch;
        }
    }
}
