using CalcGains.Model;
using CalcGains.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        #endregion
        

        public OverviewViewModel()
        {
            _productsList = ProductsSaver.LoadFromCsv();
            ChangeSearchReesultsCommand = new RelayCommand<string>(ChangeSearchReesults);
            RaisePropertyChanged();
        }

        private void ChangeSearchReesults(string newSearch)
        {
            SearchText = newSearch;
        }
    }
}
