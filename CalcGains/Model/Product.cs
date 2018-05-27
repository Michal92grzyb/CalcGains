using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcGains.Model
{
    public class Product
    {
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Carbs { get; set; }  
        public double Fat { get; set; }
        public double Protein { get; set; }

        public Product(string name, double calories, double carbs, double fat, double protein)
        {
            Name = name;
            Calories = calories;
            Carbs = carbs;
            Fat = fat;
            Protein = protein;
        }
    }
}
