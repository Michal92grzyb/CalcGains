using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcGains.Model
{
    public class Meal
    {
        public List<Component> Components { get; set; }

        public Meal(List<Component> components)
        {
            Components = components;
        }
    }
}
