using System;
using System.Collections.Generic;

namespace Challenge_03
{
    internal class ProgramUI
    {
        KOutingsRepository _kOutingsRepo = new KOutingsRepository();
        List<KOutings> _outingsList;

        int _response;

        internal void Run()
        {
            _outingsList = _kOutingsRepo.GetOutingsList();

            while (_response != 5)
            {
                IntialPrompt();
                switch (_response)
                {
                    case 1:
                        DisplayAllOutings();
                        break;
                    case 2:
                        GetOutingInfo();
                        DisplayAllOutings();
                        break;


                    default:
                        Console.WriteLine("Please choose an number from the list..");
                        break;
                        
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayAllOutings()
        {
            Console.WriteLine("OutingType\t#ofAttendees\tDate\tCostPerPerson\tCostPerEvent"); 
            foreach (KOutings outing in _outingsList)
                Console.WriteLine($"{outing.Outing}\t\t{outing.Attendees}\t\t{outing.Date}\t\t{outing.CostPerson}\t\t{outing.CostEvent}");
        }
        public void GetOutingInfo()
        {
            KOutings newOuting = new KOutings();

            Console.WriteLine("Enter the outing type");
                string type = Console.ReadLine();
                newOuting.Outing = type;

            Console.WriteLine("Enter the number of attendees");
                decimal attendees = decimal.Parse(Console.ReadLine());
                newOuting.Attendees = attendees;

            Console.WriteLine("Enter the date of the outing");
                string date = Console.ReadLine();
                newOuting.Date = date;

            Console.WriteLine("Enter the cost per person");
            decimal costPerson = decimal.Parse(Console.ReadLine());
            newOuting.CostPerson = costPerson;

            decimal costEvent = costPerson * attendees;
            newOuting.CostEvent = costEvent;

            _kOutingsRepo.AddOutingToList(newOuting);

        }

        public void IntialPrompt()
        {
            Console.WriteLine("Enter the number of the next step you would like to take:\n\t" +
                "1. Display all outings\n\t" +
                "2. Add a new outing to the list\n\t" +
                "3. Display the costs for all outings this year\n\t" +
                "4. Display the costs by outing type\n\t" +
                "5. Exit this menu");
            _response = int.Parse(Console.ReadLine());
        }
    }
}