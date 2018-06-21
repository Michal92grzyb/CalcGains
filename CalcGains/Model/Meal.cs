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
            _dateConsumed = DateTime.Now;
        }

        public Meal()
        {
            Components = new List<Component>();
            _dateConsumed = DateTime.Now;
        }

        public double TotalWeight
        {
            get
            {
                double returnValue = 0;
                foreach (var comp in Components)
                {
                    returnValue += comp.Weight;
                }
                return returnValue;
            }
        }

        public double TotalCalories
        {
            get
            {
                return Components.Sum(x => x.TotalCarbohydrates);
            }
        }

        public double TotalProtein
        {
            get
            {
                return Components.Sum(x => x.TotalProtein);
            }
        }

        public double TotalFat
        {
            get
            {
                return Components.Sum(x => x.TotalFat);
            }
        }

        public double TotalCarbohydrates
        {
            get
            {
                return Components.Sum(x => x.TotalCarbohydrates);
            }
        }

        private DateTime _dateConsumed;
        public DateTime DateConsumed
        {
            get { return _dateConsumed; }
            set { _dateConsumed = value; }
        }
    }
}
