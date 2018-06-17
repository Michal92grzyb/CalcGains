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

        public Component(Product product, double weight)
        {
            Product = product;
            Weight = weight;
        }
    }
}
