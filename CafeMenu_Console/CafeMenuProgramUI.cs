using CafeMenu_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenu_Console
{
    public class CafeMenuProgramUI
    {
        private readonly CafeMenuRepository _cafeMenuRepo = new CafeMenuRepository();

        public void Run() // make this private
        {
            SeedTheList();
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
                    "1. Add a menu item \n" +
                    "2. Delete a menu item by meal number \n" +
                    "3. See all menu items \n" +
                    "4. Delete all menu items \n" +
                    "5. Exit \n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        // Add a menu item
                        AddMenuItem();
                        break;
                    case "2":
                        // Delete a menu item by meal number
                        DeleteMenuItem();
                        break;
                    case "3":
                        // See all menu items
                        SeeAllMenuItems();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    case "4":
                        // Delete all menu items
                        DeleteTheMenu();
                        break;
                    case "5":
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

        private void AddMenuItem()
        {
            int newMealNumber = PromptForMealNumber();
            if (newMealNumber <= 0)
            {
                Console.WriteLine("Sorry. There was a problem. Please try again. \n" +
                    "Press any key to continue..");

            }
            else
            {
                Console.WriteLine("What's the name if this meal?");
                string newMealName = Console.ReadLine();
                Console.WriteLine("Describe the meal.");
                string newMealDescription = Console.ReadLine();
                Console.WriteLine("What are the ingredients?");
                string newMealIngredients = Console.ReadLine();
                Console.WriteLine("What's the price of this meal? ");
                decimal newMealPrice = Convert.ToDecimal(Console.ReadLine());

                MenuItem newMeal = new MenuItem(newMealNumber, newMealName, newMealDescription, newMealIngredients, newMealPrice);
                if (!_cafeMenuRepo.AddItemToMenu(newMeal))
                {
                    Console.WriteLine("Sorry. Your new meal wasn't added. Please try again.");
                }
                else
                {
                    Console.WriteLine($"Your new meal is \n" +
                    $"#{newMealNumber}   {newMealName}                        ${newMealPrice} \n" +
                    $"      {newMealDescription} \n" +
                    $"      {newMealIngredients} \n" +
                    "Press any key to continue...");
                    Console.ReadLine();
                }
            }

        } // AddMenuItem method

        private int PromptForMealNumber()
        {
            Console.WriteLine("Please enter a number for the meal you're adding.");
            int newMealNumber;
            bool checkForNumber = true;

            while (checkForNumber)
            {
                // READ THE MEAL NUMBER FOR THE NEW MEAL TO BE ADDED 
                string newMealNumberInput = Console.ReadLine();
                // CONVERT THE MEAL NUMBER TO INTEGER. IF NOT ENTERED, NEWMEALNUMBER = 0
                newMealNumber = Convert.ToInt32(string.IsNullOrEmpty(newMealNumberInput) ? "0" : newMealNumberInput);
                //newMealNumber = Convert.ToInt32(string.IsNullOrEmpty(Console.ReadLine()) ? "0" : Console.ReadLine());
                // IF A MEAL NUMBER WASN'T ENTERED, PROMPT FOR ANOTHER
                if (newMealNumber == 0)
                    {
                        Console.WriteLine("Please enter a valid Meal Number.");

                    }
                // IF A MEAL NUMBER WAS ENTERED, SEE IF THERE IS ALREADY A MEAL WITH THAT NUMBER ON THE MENU
                else
                    {
                        MenuItem mealInList = _cafeMenuRepo.GetMenuItemByMealNumber(newMealNumber);

                        // Check to see if the selected Meal Number has already been assigned to a Menu Item
                        // If there is a meal in the list with the specified number, ask for another number
                        if (mealInList != null)
                        {
                            Console.WriteLine($"{mealInList.MealNumber} already exists as {mealInList.MealName} \n" +
                                $"Please enter another Meal Number.");
                        }
                        else
                        {
                            // stop the while loop when a Meal Number has been entered which is not in use
                            checkForNumber = false;
                            return newMealNumber;
                        }
                    }


            } // while loop
            // I'M REQUIRED TO HAVE A RETURN HERE. IF THIS CODE HITS, ASK FOR ANOTHER MEAL NUMBER
            return -1;
        }

private void DeleteMenuItem()
        {
            bool continueLooping = true;
            SeeAllMenuItems();

            // LOOP THROUGH THE MENU TO FIND THE REQUESTED MENU ITEM TO DELETE
            while (continueLooping)
            {
                // PROMPT THE USER FOR THE MENU ITEM TO DELETE
                Console.WriteLine("\nWhich meal number would you like to delete?");
                //int itemNumberToDelete = Convert.ToInt32(Console.ReadLine());
                string itemStringToDelete = Console.ReadLine();
                // IF THEY DON'T ENTER A VALUE, PROMPT AGAIN
                if(itemStringToDelete == "")
                {
                    Console.WriteLine("Please enter a valid meal number \n" +
                        "Press any key to continue...");
                }
                else
                {
                    // RETRIEVE THE MENU ITEM WITH THE SPECIFIED MEAL NUMBER
                    int itemNumberToDelete = Convert.ToInt32(itemStringToDelete);
                    MenuItem itemToDelete = _cafeMenuRepo.GetMenuItemByMealNumber(itemNumberToDelete);

                    // DELETE THE MENU ITEM
                    //bool itemWasDeleted = _cafeMenuRepo.DeleteMenuItem(itemToDelete);
                    if (!_cafeMenuRepo.DeleteMenuItem(itemToDelete))
                    {
                        // THE DELETE FAILED
                        Console.WriteLine("Sorry. The item could not be deleted.\n" +
                            "Please try again. \n" +
                            "Press any key to continue...");
                        Console.ReadLine();
                    }
                    else
                    {
                        // THE MENU ITEM WAS DELETED. STOP THE WHILE LOOP
                        continueLooping = false;
                        Console.WriteLine($"Meal #{itemToDelete.MealNumber} {itemToDelete.MealName} was removed from the menu. \n" +
                            "Press any key to continue...");
                        Console.ReadLine();

                    }

                }

            } // while loop

        } // DeleteMenuItem method

        private void SeeAllMenuItems()
        {
            // RETRIEVE THE LIST OF ALL MENU ITEMS INTO _CAFEMENUREPO, A LIST OF TYPE MENUITEM
            List<MenuItem> listOfAllMenuItems = _cafeMenuRepo.GetAllMenuItems();
            Console.Clear();
            Console.WriteLine("Welcome to Komodo Cafe!. \n" +
                $"Today's Menu for {DateTime.Now.DayOfWeek} {DateTime.Now.Date.Month}/{DateTime.Now.Date.Day}/{DateTime.Now.Date.Year}\n");

            // WRITE EACH MENU ITEM TO THE DISPLAY
            foreach (MenuItem menuItem in listOfAllMenuItems)
            {
                Console.WriteLine($"#{menuItem.MealNumber,-5}" +
                                  $"{menuItem.MealName,-45}" +
                                  $"${menuItem.MealPrice,6}");
                Console.WriteLine("         {0,-45}",menuItem.MealDescription);
                Console.WriteLine("         {0,-45}\n\n", menuItem.MealIngredients);
            }

        } // SeeAllMenuItems method

        private void DeleteTheMenu()
        {
            // DELETE ALL CONTENTS OF THE MENU LIST AND RETURN THE EMPTY LIST TO EMPTYLIST
            List<MenuItem> emptyList = _cafeMenuRepo.DeleteAllMenuItems();
            // IF THE LIST IS EMPTY, THE DELETE WAS SUCCESSFUL
            if (emptyList.Count == 0)
            {
                Console.WriteLine("The menu has been cleared. All meals have been removed. \n" +
                    "Press any key to continue...");
                Console.ReadLine();
            }
            else
            // THE DELETE FAILED
            {
                Console.WriteLine("There was a problem. /n" +
                    "The menu wasn't cleared. All items have not been removed. \n" +
                    "Press any key to continue...");
                Console.ReadLine();

            }

        } // DeleteTheMenu method

        private void SeedTheList()
        {
            MenuItem seedMenuItem1 = new MenuItem(1, "Farmer’s Market Bowl", "Fresh greens and vegetables direct from the Farmer's Market.", "Baby spinach, quinoa, tomatoes, red onion, fresh mozzarella and green goddess dressing", 10.95m);
            MenuItem seedMenuItem2 = new MenuItem(2, "Wild Turkey Sandwich", "Don't be a turkey. Buy this sandwich.", "Roast turkey, brie, apple slices, mixed greens, & apple butter spread on a grilled ciabatta roll", 10.25m);
            MenuItem seedMenuItem3 = new MenuItem(3, "Black Goat", "Try it. It's not baaaaa'd at all.", "Roast turkey, whipped goat cheese, blackberry preserves and baby spinach on multi grain bread", 10.25m);
            MenuItem seedMenuItem4 = new MenuItem(4, "Salmon BLT", "Swim upstream and enjoy.", "Blackened salmon with crispy bacon, baby spinach, roasted tomatoes, and pesto mayo on grilled ciabatta", 13.95m);

            _cafeMenuRepo.AddItemToMenu(seedMenuItem1);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem2);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem3);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem4);

        }

    } // class CafeMenuProgramUI
} // namespace CafeMenu_Console
