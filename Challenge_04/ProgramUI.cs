using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge_04
{
    internal class ProgramUI
    {
        KBadgesRepository _kBadgesRepo = new KBadgesRepository();
        Dictionary<int, List<string>> _badgedic;

        int _response;

        internal void Run()
        {
            _badgedic = _kBadgesRepo.GetDictionary();
            SeedData();
            while (_response != 4)
            {
                MainMenu();
                switch (_response)
                {
                    case 1:
                        GetBadgeInfo();
                        break;
                    case 2:
                        UpdateBadge();
                        break;
                }

            }
        }
        private void MainMenu()
        {
            Console.WriteLine("Hello, Security Admin, What would you like to do?\n\t" +
                "1. Add a badge\n\t" +
                "2. Update a badge\n\t" +
                "3. List all badges \n\t" +
                "4. Exit this menu");
            _response = int.Parse(Console.ReadLine());
        }
        private void GetBadgeInfo()
        {
            KomodoBadge newBadge = new KomodoBadge();


            Console.WriteLine("What is the number on the badge?");
            int badgeID = int.Parse(Console.ReadLine());
            newBadge.BadgeID = badgeID;

            Console.WriteLine("List a door that it should access");
            string door = (Console.ReadLine());

            _kBadgesRepo.AddDoortoList(door);

            bool _doorPlus = true;
            while (_doorPlus)
            {
                Console.WriteLine("Should it access another door? (y/n)");
                var another = Console.ReadLine();

                switch (another)
                {
                    case "y":
                        Console.WriteLine("List a door that it should access");
                        string doorPlus = Console.ReadLine();
                        _kBadgesRepo.AddDoortoList(doorPlus);
                        break;
                    case "n":
                        _doorPlus = false;
                        break;
                }
            }
        }
        private void UpdateBadge()
        {
            Dictionary<int, List<string>> _badgedic = new Dictionary<int, List<string>>();
            List<string> doors = new List<string>();

            Console.WriteLine("Enter the ID number of the badge you would like to update:");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine($"Badge #{badgeID} has access to doors ");
            PrintDoorsByBadge(badgeID);

            Console.ReadKey();

            Console.WriteLine("What would you like to do?\n\t" +
                "1. Remove a door\n\t" +
                "2. Add a door");
            int update = int.Parse(Console.ReadLine());

            switch (update)
            {
                case 1:
                    Console.WriteLine("Which door would you like to remove?");
                    string remove = Console.ReadLine();

                    _kBadgesRepo.RemoveDoorFromList(remove);

                    Console.WriteLine($"Door {remove} removed./n" +
                    $"Badge ID {badgeID} has access to door {doors}.");
                    break;

                case 2:
                    Console.WriteLine("Which door would you like to add?");
                    string add = Console.ReadLine();

                    _kBadgesRepo.AddDoortoList(add);

                    Console.WriteLine($"Door {add} added./n" +
                    $"Badge ID {badgeID} has access to door {doors}.");
                    break;
            }
        }

        private void ListAllBadges()
        {
            foreach (KeyValuePair<int, List<string>> pair in _badgedic)
            {
                Console.WriteLine($"{pair.Key}\t");
                Console.WriteLine("Door access    ");
                foreach (string displayDoors in pair.Value)
                {
                    Console.WriteLine($"{displayDoors}\n");
                }
            }
        }
        private void PrintDoorsByBadge(int id)
        {
            List<string> doors = new List<string>();
            foreach (var badge in _badgedic)
            {
                if (id == badge.Key)
                {
                    doors = badge.Value;
                }
            }

            foreach (var door in doors)
            {
                Console.WriteLine(door);
            }
        }


        private void SeedData()
        {
            _kBadgesRepo.AddBadgeToDictionary(new KomodoBadge(123, new List<string>() { "A1", "A2", "A3" }));
            _kBadgesRepo.AddBadgeToDictionary(new KomodoBadge(456, new List<string>() { "A4", "A5", "A6" }));
            _kBadgesRepo.AddBadgeToDictionary(new KomodoBadge(789, new List<string>() { "A7", "A8", "A9" }));
        }

    }
}