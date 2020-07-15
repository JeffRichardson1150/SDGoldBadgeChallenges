using InsuranceClaims_Class;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims_Console
{
    class Claims_ProgramUI
    {
        private readonly ClaimsRepository _claimsRepo = new ClaimsRepository();

        public void Run() // make this private
        {
            SeedTheQueue();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                // Editor shortcut : When you use the \n for new line, after typing the \n in the code, hit Enter and the editor will create a new line of code with a ""
                Console.WriteLine("Enter the number of the option you'd like to select: \n" +
                    "1. See all claims \n" +
                    "2. Process the next claim \n" +
                    "3. Create a new claim \n" +
                    "4. Exit \n");
                string userInput = CheckForInput();

                switch (userInput)
                {
                    case "1":
                        // See all claims
                        ShowAllClaims();
                        break;
                    case "2":
                        // Process the next claim
                        ProcessNextClaim();
                        break;
                    case "3":
                        // Create a new claim
                        EnterNewClaim();
                        break;
                    case "4":
                        // exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine($"{userInput} is not a valid option. \n" +
                            "Please enter a valid number between 1 and 5. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }  // switch case

            } // while loop
        } // RunMenu method


        private void ShowAllClaims()
        {
            // return the queue of all existing claims
            Queue<Claim> allClaims = _claimsRepo.GetAllClaims();
            // Print the report header
            Console.Clear();
            PrintClaimHeader();

            // Print a line in the report for each claim in the queue
            foreach (Claim claim in allClaims)
            {
                PrintClaim(claim);
            }
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadLine();
        }

        private void PrintClaimHeader()
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-30}{3,-15}{4,-20}{5,-15}{6,-15}",
                    "Claim ID", "Type", "Description", "Amount", "Date Of Accident", "Date Of Claim", "Valid");
            Console.WriteLine("{0,-10}{1,-10}{2,-30}{3,-15}{4,-20}{5,-15}{6,-15}",
                    "---------", "------", "---------------", "--------", "----------------", "-------------", "-----");
        }

        private void PrintClaim(Claim claim)
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-30}{3,-15}{4,-20}{5,-15}{6,-15}", claim.ClaimID, claim.ClaimType, claim.Description, claim.ClaimAmount, claim.DateOfIncident.ToString("MM/dd/yy"), claim.DateOfClaim.ToString("MM/dd/yy"), claim.IsValid);

        }

        private void ProcessNextClaim()
        {
            // Create a new queue which contains all the claims in the queue
            Queue<Claim> allClaims = _claimsRepo.GetAllClaims();

            // Look at the next claim in the queue and print the claim to the display
            Claim nextClaim = allClaims.Peek();
            Console.Clear();
            PrintClaimHeader();
            PrintClaim(nextClaim);

            Console.WriteLine("\n Would you like to process this claim?\n" +
                "Please respond y / n");
            string processClaim = CheckForInput().ToLower();

            switch (processClaim.Substring(0, 1)) // just check the first character of the response
            {
                case "y":
                    // Process this claim. Dequeue the claim
                    allClaims.Dequeue();
                    break;
                case "n":
                    // Do nothing; not processing the claim.
                    break;
                default:
                    Console.WriteLine("That was not a valid response");
                    break;
            }
        }

        private void EnterNewClaim()
        {
            // Create an empty Claim object (newClaim)
            Claim newClaim = new Claim();

            // Get the Claim ID
            Console.Clear();
            int availableClaimID = RequestAnAvailableClaimID();
            //Console.WriteLine("Please enter a claim ID");
            // check the queue for this claim ID & request another if it already exists. If it doesn't exist
            //newClaim.ClaimID = Convert.ToInt32(CheckForInput());

            newClaim.ClaimID = availableClaimID;

            Console.WriteLine("Please enter a claim type \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft \n");
            string claimType = Console.ReadLine();
            switch (claimType)
            {
                case "1":
                    // Car
                    newClaim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    // Home
                    newClaim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    // Theft
                    newClaim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    // invalid entry
                    break;
            }
            // Get the description
            Console.WriteLine("Please provide a description of the claim.");
            newClaim.Description = CheckForInput();

            // Get the amount of the claim
            Console.WriteLine("Please provide a dollar value of the claim.");
            string claimAmount = CheckForInput();
            newClaim.ClaimAmount = claimAmount.Substring(0, 1) == "$" ? Convert.ToDecimal(claimAmount.Substring(1)) : Convert.ToDecimal(claimAmount);

            // Get the date of the incident
            Console.WriteLine("Please enter the date of the incident (mm/dd/yyyy)");
            //DateTime dateOfIncident =
            newClaim.DateOfIncident = Convert.ToDateTime(CheckForInput());

            // Get the date of the claim filing
            Console.WriteLine("Please enter the date of the claim filing (mm/dd/yyyy)");
            //DateTime dateOfIncident =
            newClaim.DateOfClaim = Convert.ToDateTime(CheckForInput());

            _claimsRepo.AddClaimToQueue(newClaim);
            Console.Clear();
            Console.WriteLine("You've created the following claim. \n\n");
            PrintClaimHeader();
            PrintClaim(newClaim);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadLine();

        }

        private int RequestAnAvailableClaimID()
        {
            Console.WriteLine("Please enter a claim ID");
            // check the queue for this claim ID & request another if it already exists. If it doesn't exist
            Queue<Claim> allClaims = _claimsRepo.GetAllClaims();
            bool getMoreInput = true;
            bool keepCheckingForID = true;
            int inputClaimID = 0;

            while (getMoreInput)
            {
                keepCheckingForID = true;
                inputClaimID = Convert.ToInt32(CheckForInput());

                // Create an enumerator to traverse the queue
                IEnumerator<Claim> enumerator =
                    allClaims.GetEnumerator();

                // If MoveNext passes the end of the 
                // collection, the enumerator is positioned 
                // after the last element in the Queue 
                // and MoveNext returns false. 
                while (enumerator.MoveNext() && keepCheckingForID)
                {
                    //Console.WriteLine(enumerator.Current.ClaimID);
                    if (enumerator.Current.ClaimID == inputClaimID)
                    {
                        keepCheckingForID = false;
                        Console.WriteLine($"Claim ID #{inputClaimID} already exists. \n" +
                            "Please select another Claim ID.");
                        getMoreInput = true;
                    }
                    else
                    {
                        getMoreInput = false;
                    }
                }

            } // while loop
            return inputClaimID;
        }

        private void SeedTheQueue()
        {
            Claim seedClaim1 = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim seedClaim2 = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim seedClaim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));

            _claimsRepo.AddClaimToQueue(seedClaim1);
            _claimsRepo.AddClaimToQueue(seedClaim2);
            _claimsRepo.AddClaimToQueue(seedClaim3);
        }

        private string CheckForInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter a valid value");
                input = Console.ReadLine();
            } 
            return input;
        }
    } // class Claims_ProgramUI
}
