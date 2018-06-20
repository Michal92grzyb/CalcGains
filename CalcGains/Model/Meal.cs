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
                double returnValue = 0;
                foreach (var comp in Components)
                {
                    returnValue += comp.Product.Calories;
                }
                return returnValue;
            }
        }

        public double TotalProtein
        {
            get
            {
                double returnValue = 0;
                foreach (var comp in Components)
                {
                    returnValue += comp.Product.Protein;
                }
                return returnValue;
            }
        }

        public double TotalFat
        {
            get
            {
                double returnValue = 0;
                foreach (var comp in Components)
                {
                    returnValue += comp.Product.Fat;
                }
                return returnValue;
            }
        }

        public double TotalCarbohydrates
        {
            get
            {
                double returnValue = 0;
                returnValue = Components.Sum(x => x.Product.Carbs);
                //foreach (var comp in Components)
                //{
                //    returnValue += comp.Product.Carbs;
                //}
                return returnValue;
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
