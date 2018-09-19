using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcGains.Model
{
    public class DailyBalance
    {
        private List<Meal> _dailyMeals;
        public ObservableCollection<Meal> DailyMeals
        {
            get
            {
                return new ObservableCollection<Meal>(_dailyMeals);
            }
            set
            {
                _dailyMeals = new List<Meal>(value);
            }
        }

        private DateTime _date;
        public DateTime Date { get; set; }


    }
}
