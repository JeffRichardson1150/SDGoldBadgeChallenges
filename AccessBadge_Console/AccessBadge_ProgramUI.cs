using AccessBadge_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessBadge_Console
{
        class AccessBadge_ProgramUI
    {
        AccessBadgeRepository _repo = new AccessBadgeRepository();
        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all badges \n" +
                    "4. Exit \n");
                string userInput = CheckForInput();

                switch (userInput)
                {
                    case "1":
                        // See all claims
                        AddABadge();
                        break;
                    case "2":
                        // Process the next claim
                        UpdateABadge();
                        break;
                    case "3":
                        // Create a new claim
                        ListAllBadges();
                        break;
                    case "4":
                        // exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine($"{userInput} is not a valid option. \n" +
                            "Please enter a valid number between 1 and 4. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }  // switch case

            } // while loop
        } // RunMenu method

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


        private void AddABadge()
        {
            List<string> listOfDoors = new List<string>();

            Console.WriteLine("What is the number on the badge? :");
            int badgeID = Convert.ToInt32(CheckForInput());
            Console.WriteLine("List a door that it needs access to: ");

            // build a list of doors to add to the badge
            listOfDoors.Add(CheckForInput());

            string moreDoors = "y";
            // add doors to the list there are ain't no mo
            while (moreDoors == "y")
            {
                Console.WriteLine("\n Any other doors?\n" +
                                    "Please respond y / n");
                moreDoors = CheckForInput().ToLower();

                switch (moreDoors.Substring(0, 1)) // just check the first character of the response
                {
                    case "y":
                        // Add the next door to the list
                        Console.WriteLine("List a door that it needs access to: ");
                        listOfDoors.Add(CheckForInput());
                        break;
                    case "n":
                        // Do nothing; no more doors to add.
                        break;
                    default:
                        Console.WriteLine("That was not a valid response");
                        break;
                }
            }

            bool badgeCreated = _repo.CreateNewBadge(badgeID, listOfDoors);


            //bool doorWasAdded = _repo.AddDoorToList(badgeID, door);
        } // method AddABadge

        private void UpdateABadge()
        {
            Console.WriteLine("What is the badge number to update?");
            int badgeID = Convert.ToInt32(CheckForInput());
            List<string> listOfDoors = _repo.ReturnListOfDoors(badgeID);
            Console.Write($"{badgeID} has access to doors ");
            int doorsListed = 0;
            foreach (string door in listOfDoors)
            {
                doorsListed++;
                if (doorsListed > 1) 
                {
                    Console.Write(" & ");
                        };
                Console.Write($"{door}");
            }
            Console.WriteLine("\n\nWhat would you like to do?\n" +
                "1. Remove a door \n" +
                "2. Add a door");
            string updateAction = CheckForInput();
            string addOrRemove = updateAction == "1" ? "Remove" : "Add";
            Console.WriteLine($"Which door would you like to {addOrRemove}");
            string doorToChange = CheckForInput();
            bool badgeUpdated = updateAction == "1" ? _repo.RemoveDoorFromList(badgeID, doorToChange) : _repo.AddDoorToList(badgeID, doorToChange);

            if (!badgeUpdated)
            {
                Console.WriteLine("There was a problem updating badge {badgeID}");
            }
            else
            {
                string actionTaken = updateAction == "1" ? "Removed" : "Added";
                Console.WriteLine($"Door {doorToChange} was {actionTaken}");
                List<string> updatedListOfDoors = _repo.ReturnListOfDoors(badgeID);
                Console.Write($"{badgeID} has access to doors ");
                doorsListed = 0;
                foreach (string door in listOfDoors)
                {
                    doorsListed++;
                    if (doorsListed > 1)
                    {
                        Console.Write(" & ");
                    };
                    Console.Write($"{door}");
                }
                Console.ReadLine();
            }
        }

        private void ListAllBadges()
        {
                Dictionary<int, List<string>> accessBadgeDictionary = new Dictionary<int, List<string>>();  // BadgeID, List of Door Names

            accessBadgeDictionary = _repo.returnTotalDictionary();
            // get all the key values ( the badge numbers)
            Dictionary<int, List<string>>.KeyCollection keyColl = accessBadgeDictionary.Keys;
            //foreach (KeyValuePair<int, List<string>> kvp in accessBadgeDictionary)
            Console.WriteLine("Badge #     Door Access");
            foreach (int badge in keyColl)
            {
                Console.Write($"{badge}         ");
                List<string> listOfDoors = accessBadgeDictionary[badge];
                int numberOfDoors = 0;
                foreach (string door in listOfDoors)
                {
                    numberOfDoors++;
                    if (numberOfDoors > 1)
                    {
                        Console.Write(", ");
                    }
                    Console.Write($"{door}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    } // class
}
