using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcGains.Model
{
    public class Component
    {
        public double Weight { get; set; }
        public Product Product { get; set; }

        public double TotalCalories
        {
            get { return Product.Calories * (Weight / 100); }
        }
        public double TotalProtein
        {
            get { return Product.Protein * (Weight / 100); }
        }
        public double TotalFat
        {
            get { return Product.Fat * (Weight / 100); }
        }
        public double TotalCarbohydrates
        {
            get { return Product.Carbs * (Weight / 100); }
        }

        public Component(Product product, double weight)
        {
            Product = product;
            Weight = weight;
        }
    }
}
