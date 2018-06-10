﻿using CalcGains.Model;
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
            RemoveProductCommand = new RelayCommand(RemoveProduct);
            EditProductCommand = new RelayCommand(EditProduct);
            AddProductVisibility = false;
            _productsList = ProductsSaver.LoadFromCsv();
            RaisePropertyChanged();
        }

        private void ShowAddProductBar()
        {
            AddProductVisibility = !AddProductVisibility;
        }

        private bool _isEditingProduct = false;

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
                    _productsList.Add(newProduct);
                    Products = new ObservableCollection<Product>(_productsList);
                    Calories = Protein = Fat = Carbs = ProductName = string.Empty;
                    ProductsSaver.SaveToCsv(_productsList);
                }
                else
                {
                    double kcal = double.Parse(Calories);
                    double prot = double.Parse(Protein);
                    double fatty = double.Parse(Fat);
                    double carb = double.Parse(Carbs);
                    Product newProduct = new Product(ProductName, kcal, prot, fatty, carb);
                    int index = Products.IndexOf(_selectedProduct);
                    _productsList.RemoveAt(index);
                    _productsList.Insert(index, newProduct);
                    Products = new ObservableCollection<Product>(_productsList);
                    Calories = Protein = Fat = Carbs = ProductName = string.Empty;
                    ProductsSaver.SaveToCsv(_productsList);
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
