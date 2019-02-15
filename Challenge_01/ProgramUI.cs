using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Challenge_01.KomodoMenu;

namespace Challenge_01
{
    internal class ProgramUI
    {
        KomodoRepository _komodoRepo = new KomodoRepository();
        List<KomodoMenu> _menuList;

        int _response;


        public void Run()
        {
            _menuList = _komodoRepo.GetKomodoMenu();
            SeedData();

            while (_response != 4)
            {
                FirstUserPrompts();
                switch (_response)
                {
                    case 1:
                        SeeKomodoMenu();
                        break;
                    case 2:
                        AddMenuItem();
                        break;
                    case 3:
                        RemoveMenuItem();
                        break;
                    case 4:
                        Console.WriteLine("Exiting app...");
                        break;
                    default:
                        Console.WriteLine("Please enter a number from the list.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            void FirstUserPrompts()
            {
                Console.WriteLine("Hello, Here are the options to work with the Komodo Menu. Please choose one:\n\t" +
                    "1.  See the current menu\n\t" +
                    "2.  Add a new meal item to the menur\n\t" +
                    "3.  Remove a meal item from the menu\n\t" +
                    "4.  Exit this app");
                string responseStr = Console.ReadLine();
                _response = int.Parse(responseStr);
            }
        }

        private void SeedData()
        {
            _komodoRepo.AddItemToList(new KomodoMenu(1, "Dragon", true, "peppers, beans, rice", 5.25m));
            _komodoRepo.AddItemToList(new KomodoMenu(2, "Prince", false, "beef, broccoli, sauce", 4.50m));
            _komodoRepo.AddItemToList(new KomodoMenu(3, "Princess", true, "noodles, carrots, sauce", 2.5m));
        }

        private void RemoveMenuItem()
        {
            SeeKomodoMenu();
            Console.WriteLine("Enter the Meal # of the menu item you would like to remove:");
            int removeItem = int.Parse(Console.ReadLine());
            foreach (KomodoMenu item in _menuList)
            {
                if (item.MealNumber == removeItem)
                {
                    _komodoRepo.RemoveItemFromList(item);
                    break;
                }
            }
        }

        private void SeeKomodoMenu()
        {
            Console.WriteLine("Meal #\tMeal Name\tVegetarian?\t\tIngredients\t\tPrice");
            foreach (KomodoMenu item in _menuList)
                Console.WriteLine($"{item.MealNumber}\t{item.MealName}\t\t{item.IsVegie}\t\t{item.MealIngreds}\t\t{item.MealPrice}"); 
        }

        private void AddMenuItem()
        {
            KomodoMenu item = new KomodoMenu();

            Console.WriteLine("What will the # of this new meal be on the menu?");
            int mealNumber = int.Parse(Console.ReadLine());
            item.MealNumber = mealNumber;

            Console.WriteLine("What name will you give to this new meal on the menu?");
            string mealName = Console.ReadLine();
            item.MealName = mealName;

            Console.WriteLine("Would you describe this new meal as vegetarian? Y or N");
            string isVegieStr = Console.ReadLine().ToLower();
            bool isVegie;
            if (isVegieStr.Contains("y"))
                isVegie = true;
            else
                isVegie = false;
            item.IsVegie = isVegie;

            Console.WriteLine("Which ingredients will be included in this new meal?");
            string ingredients = Console.ReadLine();
            item.MealIngreds = ingredients;

            Console.WriteLine("What will be the price of this new meal on the menu?");
            decimal mealPrice = decimal.Parse(Console.ReadLine());
            item.MealPrice = mealPrice;

            _komodoRepo.AddItemToList(item);
        }
    }
}
