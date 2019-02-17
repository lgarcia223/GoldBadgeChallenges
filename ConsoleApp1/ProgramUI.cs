using System;
using System.Collections.Generic;
using static Challenge_02.KClaims;

namespace Challenge_02
{
    internal class ProgramUI
    {
        KClaimsRepository _kclaimsRepo = new KClaimsRepository();
        List<KClaims> _claimList;
        Queue<KClaims> _claimQueue;

        int _initialChoice;

        internal void Run()
        {
            _claimList = _kclaimsRepo.SeeClaimList();
            _claimQueue = _kclaimsRepo.GetClaimQueue();
            SeedData();

            while (_initialChoice != 4)
            {
                InitialUserPrompts();
                switch (_initialChoice)
                {
                    case 1:
                        SeeAllClaims();
                        break;
                    case 2:
                        Console.WriteLine($"Here are the details of the next claim to be resolved:\n" +
                            $"ClaimID: {_claimQueue.Peek().ClaimId}\n" +
                            $"Type: {_claimQueue.Peek().TypeofClaim}\n" +
                            $"Description:{_claimQueue.Peek().Descrip}\n" +
                            $"Amount: ${_claimQueue.Peek().ClaimAmount}\n" +
                            $"DateOfAccident: {_claimQueue.Peek().IncidentDate}\n" +
                            $"DateOfClaim: {_claimQueue.Peek().ClaimDate}\n" +
                            $"IsValid: {_claimQueue.Peek().IsValid}\n\n" +

                            $"Do you want to resolve this claim now (y/n)?");

                        var resolve = Console.ReadLine();
                        if
                            (resolve.ToLower().Contains("y"))
                        {
                            _kclaimsRepo.ResolveNextClaim();
                            break;
                        }
                        else
                        {
                            InitialUserPrompts();
                            break;
                        }
                    case 3:
                        EnterNewClaim();
                        break;
                    case 4:
                        Console.WriteLine("Exiting app");
                        break;
                }

            }
            Console.Write("Press any key to continue..");
            Console.ReadKey();
            Console.Clear();
        }

        private void EnterNewClaim()
        {
            KClaims newClaim = new KClaims();

            Console.WriteLine("Enter the claim id:");
            string id = Console.ReadLine();
            newClaim.ClaimId = id;

            Console.WriteLine("Enter the claim type:\n\t" +
                "1. Car \n\t" +
                "2. Home \n\t" +
                "3. Theft");
            int typeInt = int.Parse(Console.ReadLine());
            ClaimType type = _kclaimsRepo.GetTypeFromInt(typeInt);
            newClaim.TypeofClaim = type;

            _kclaimsRepo.AddClaimToList(newClaim);



            Console.WriteLine("Enter a claim description:");
            string describe = Console.ReadLine();
            newClaim.Descrip = describe;

            Console.WriteLine("Amount of Damage: $");
            decimal amount = decimal.Parse(Console.ReadLine());
            newClaim.ClaimAmount = amount;

            Console.WriteLine("Date of Accident:");
            string accDate = Console.ReadLine();
            newClaim.IncidentDate = accDate;

            Console.WriteLine("Date of Claim:");
            string claimDate = Console.ReadLine();
            newClaim.ClaimDate = claimDate;

            Console.WriteLine("This claim is valid.  (true or false)");
            bool valid = bool.Parse(Console.ReadLine());
            newClaim.IsValid = valid;
        }

        public void InitialUserPrompts()
        {
            Console.WriteLine("Please choose a number option from the list below:\n\t" +
                "1. See all Komodo Claims\n\t" +
                "2. Resolve next claim in the queue\n\t" +
                "3. Enter a new claim\n\t" +
                "4. Exit this menu");

            _initialChoice = int.Parse(Console.ReadLine());
        }

        public void PrintClaimQueue()
        {
            foreach (var claim in _claimQueue)
                Console.WriteLine($"ClaimID: {claim.ClaimId}\nType: {claim.TypeofClaim}\nDescription: {claim.Descrip}\nAmount: {claim.ClaimAmount}\nDateOfAccident: {claim.IncidentDate}\nDateOfClaim: {claim.ClaimDate}\nIsValid: {claim.IsValid}\n");

        }

        public void SeedData()
        {
            _kclaimsRepo.AddClaimToList(new KClaims("1", ClaimType.Car, "Car accident on 465", 400.00m, "4/25/18", "4/27/18", true));
            _kclaimsRepo.AddClaimToList(new KClaims("2", ClaimType.Home, "House fire in kitchen", 4000.00m, "4/26/18", "4/28/18", true));
            _kclaimsRepo.AddClaimToList(new KClaims("3", ClaimType.Theft, "Stolen pancakes     ", 4.00m, "4/27/18", "6/01/18", false));
            _kclaimsRepo.AddContentToQueue(new KClaims("1", ClaimType.Car, "Car accident on 465", 400.00m, "4/25/18", "4/27/18", true));
            _kclaimsRepo.AddContentToQueue(new KClaims("2", ClaimType.Home, "House fire in kitchen", 4000.00m, "4/26/18", "4/28/18", true));
            _kclaimsRepo.AddContentToQueue(new KClaims("3", ClaimType.Theft, "Stolen pancakes     ", 4.00m, "4/27/18", "6/01/18", false));

        }

        private void SeeAllClaims()
        {
            Console.WriteLine("ClaimID\tType\tDescription\t\tAmount\tDateOfAccident\tDateofClaim\tIsValid");
            foreach (KClaims claim in _claimList)
                Console.WriteLine($"{claim.ClaimId}\t{claim.TypeofClaim}\t{claim.Descrip}\t${claim.ClaimAmount}\t{claim.IncidentDate}\t{claim.IncidentDate}\t{claim.IsValid}");
        }
    }

}