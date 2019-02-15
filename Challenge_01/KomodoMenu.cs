using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    public class KomodoMenu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public bool IsVegie { get; set; }
        public string MealIngreds { get; set; }
        public decimal MealPrice { get; set; }

        public KomodoMenu()
        {

        }

        public KomodoMenu (int mealNumber, string mealName, bool isVegie, string ingredients, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            IsVegie = isVegie;
            MealIngreds= ingredients;
            MealPrice = mealPrice;
        }
    }
}
