using System;
using System.Collections.Generic;
using System.Linq;

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
            SeedData();

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
                    case 3:
                        AllOutingsSum();
                        break;
                    case 4:
                        CostByType();
                        break;
                    case 5:
                        Console.WriteLine("Exiting, See ya later!");
                        break;
                    default:
                        Console.WriteLine("Please choose a number from the list..");
                        break;
                }
                Console.Write("Press any key to continue..");
                Console.ReadKey();
            }
        }

        private void CostByType()
        {
            var golfCost = _kOutingsRepo.OutingCostByType(OutingType.Golf);
            var bowlCost = _kOutingsRepo.OutingCostByType(OutingType.Bowling);
            var parkCost = _kOutingsRepo.OutingCostByType(OutingType.AmusementPark);
            var concertCost = _kOutingsRepo.OutingCostByType(OutingType.Concert);
            var otherCost = _kOutingsRepo.OutingCostByType(OutingType.Other);
            Console.WriteLine($"Total Golf costs:           {golfCost}");
            Console.WriteLine($"Total Bowling costs:        {bowlCost}");
            Console.WriteLine($"Total Amusement Park costs: {parkCost}");
            Console.WriteLine($"Total Concert costs:        {concertCost}");
            Console.WriteLine($"Total Other costs:          {otherCost}");
        }

        private void AllOutingsSum()
        {
            decimal outingsCost = 0;
            foreach (KOutings outing in _outingsList)
            {
                outingsCost += outing.CostEvent;
            }

            Console.WriteLine($"Total cost of all events this year: $ {outingsCost}");
        }

        private void DisplayAllOutings()
        {
            Console.WriteLine("OutingType\t#ofAttendees\tDate\tCostPerPerson\tCostPerEvent");
            foreach (KOutings outing in _outingsList)
                Console.WriteLine($"{outing.TypeofOuting}\t\t{outing.Attendees}\t\t{outing.Date}\t\t{outing.CostPerson}\t\t{outing.CostEvent}");
        }

        public void GetOutingInfo()
        {
            KOutings newOuting = new KOutings();

            Console.WriteLine("What is the outing type?\n\t" +
                "1. Golf\n\t" +
                "2. Bowling\n\t" +
                "3. Amusement Park\n\t" +
                "4. Concert\n\t" +
                "5. Other");
            int outingInt = int.Parse(Console.ReadLine());
            OutingType type = _kOutingsRepo.GetTypefromInt(outingInt);
            newOuting.TypeofOuting = type;

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
        private void SeedData()
        {
            _kOutingsRepo.AddOutingToList(new KOutings(OutingType.AmusementPark, 5, "9/25/18", 5.25m));
            _kOutingsRepo.AddOutingToList(new KOutings(OutingType.Bowling, 15, "12/20/18", 14.00m));
            _kOutingsRepo.AddOutingToList(new KOutings(OutingType.Concert, 20, "7/25/18", 3.5m));
        }

    }
}