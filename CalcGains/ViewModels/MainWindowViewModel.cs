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
using System.Windows;
using System.Windows.Input;

namespace CalcGains.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand AddProductCommand { get; private set; }
        public ICommand AddProductDoneCommand { get; private set; }
        public ICommand RemoveProductCommand { get; private set; }
        public ICommand EditProductCommand { get; private set; }

        public ICommand AddMealCommand { get; private set; }
        public ICommand AddMealDoneCommand { get; private set; }
        public ICommand AddProductToMealCommand { get; private set; }
        public ICommand RemoveMealCommand { get; private set; }

        private bool _isEditingProduct = false;

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

        private Meal _selectedMeal;
        public Meal SelectedMeal
        {
            get
            {
                return _selectedMeal;
            }
            set
            {
                _selectedMeal = value;
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
        
        private double _productToAddWeight;
        public double ProductToAddWeight
        {
            get
            {
                return _productToAddWeight;
            }
            set
            {
                _productToAddWeight = value;
                RaisePropertyChanged();
            }
        }

        private string _productToAdd;
        public string ProductToAdd
        {
            get
            {
                return _productToAdd;
            }
            set
            {
                _productToAdd = value;
                RaisePropertyChanged();
            }
        }

        public List<string> ProductsNames
        {
            get
            {
                return new List<string>(_productsList.Select(x => x.Name).OrderBy(name => name).ToList());
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

        private bool _addMealVisibility;
        public bool AddMealVisibility
        {
            get { return _addMealVisibility; }
            set
            {
                _addMealVisibility = value;
                RaisePropertyChanged();
            }
        }

        private string _addedProducts;
        public string AddedProducts
        {
            get { return _addedProducts; }
            set
            {
                _addedProducts = value;
                RaisePropertyChanged();
            }
        }

        public Meal _mealToAdd;
        public Meal MealToAdd
        {
            get { return _mealToAdd; }
            set
            {
                _mealToAdd = value;
                RaisePropertyChanged();
            }
        }

        private List<Meal> _mealList;
        public ObservableCollection<Meal> Meals
        {
            get
            {
                return new ObservableCollection<Meal>(_mealList);
            }
            set
            {
                _mealList = value.ToList<Meal>();
                RaisePropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            AddProductCommand = new RelayCommand(ShowAddProductBar);
            AddProductDoneCommand = new RelayCommand(AddProduct);
            RemoveProductCommand = new RelayCommand(RemoveProduct);
            EditProductCommand = new RelayCommand(EditProduct);
            AddMealCommand = new RelayCommand(ShowAddMealBar);
            AddMealDoneCommand = new RelayCommand(AddMeal);
            AddProductToMealCommand = new RelayCommand(AddProductToMeal);
            RemoveMealCommand = new RelayCommand(RemoveMeal);
            AddProductVisibility = false;
            AddMealVisibility = false;
            _productsList = ProductsSaver.LoadFromCsv();
            _mealList = ProductsSaver.LoadMealsFromCsv();
            AddedProducts = "Obecnie dodane produkty: ";
            RaisePropertyChanged();
        }

        private void RemoveMeal()
        {
            _mealList.Remove(SelectedMeal);
            ProductsSaver.SaveMealsToCsv(_mealList);
            Meals = new ObservableCollection<Meal>(_mealList);
        }

        private void AddProductToMeal()
        {
            Component newComponent = new Component(_productsList.Single(x => x.Name == ProductToAdd), ProductToAddWeight);
            MealToAdd.Components.Add(newComponent);
            AddedProducts += "\n" + ProductToAdd + ", waga: " + ProductToAddWeight + "g,";
        }

        private void AddMeal()
        {
            _mealList.Add(MealToAdd);
            AddMealVisibility = false;
            AddedProducts = "Obecnie dodane produkty: ";
            Meals = new ObservableCollection<Meal>(_mealList); // tutuaj
            ProductsSaver.SaveMealsToCsv(MealToAdd);
        }

        private void ShowAddMealBar()
        {
            MealToAdd = new Meal(new List<Component>());
            AddMealVisibility = true;
        }

        private void ShowAddProductBar()
        {
            AddProductVisibility = !AddProductVisibility;
        }

        private void EditProduct()
        {
            if (_selectedProduct != null)
            { 
            AddProductVisibility = true;
            ProductName = SelectedProduct.Name;
            Calories = SelectedProduct.Calories.ToString();
            Protein = SelectedProduct.Protein.ToString();
            Fat = SelectedProduct.Fat.ToString();
            Carbs = SelectedProduct.Carbs.ToString();

            _isEditingProduct = true;
            }
        }

        private void RemoveProduct()
        {
            _productsList.Remove((Product)SelectedProduct);
            Products = new ObservableCollection<Product>(_productsList);
            ProductsSaver.SaveToCsv(_productsList);
        }

        private void AddProduct()
        {
            try
            {
                if (!_isEditingProduct)
                {
                    double kcal = double.Parse(Calories);
                    double prot = double.Parse(Protein);
                    double fatty = double.Parse(Fat);
                    double carb = double.Parse(Carbs);
                    Product newProduct = new Product(ProductName, kcal, prot, fatty, carb);

                    if (!_productsList.Any(x => x.Name == newProduct.Name))
                    { 
                    _productsList.Add(newProduct);
                    Products = new ObservableCollection<Product>(_productsList);
                    Calories = Protein = Fat = Carbs = ProductName = string.Empty;
                    ProductsSaver.SaveToCsv(_productsList);
                    }
                    else
                        MessageBox.Show("same data", "Error");
                }
                else
                {
                    double kcal = double.Parse(Calories);
                    double prot = double.Parse(Protein);
                    double fatty = double.Parse(Fat);
                    double carb = double.Parse(Carbs);
                    Product newProduct = new Product(ProductName, kcal, prot, fatty, carb);
                    int index = Products.IndexOf(_selectedProduct);
                    if (!_productsList.Where((v, i) => i != index).Any(x => x.Name == newProduct.Name))
                    {
                        _productsList.RemoveAt(index);
                        _productsList.Insert(index, newProduct);
                        Products = new ObservableCollection<Product>(_productsList);
                        Calories = Protein = Fat = Carbs = ProductName = string.Empty;
                        ProductsSaver.SaveToCsv(_productsList);
                    }
                    else
                        MessageBox.Show("same data", "Error");
                }
            }
            catch
            {
                MessageBox.Show("wrong data", "Error");

            }
            finally
            {
                _isEditingProduct = false;
                AddProductVisibility = false;
            }
        }
    }
}
