Three challenges were done

Challenge 1: Cafe

Komodo Cafe
Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.

 

The Menu Items:
A meal number, so customers can say "I'll have the #5"
A meal name
A description
A list of ingredients,
A price
 

I accomplished the following:
Create a Menu Class with properties, constructors, and fields.
//  public class MenuItem
//  {
//		int MealNumber{ get; set; }
//		string MealName{ get; set; }
//		string MealDescription{ get; set; }
//		List MealIngredients{ get; set; }
//		decimal MealPrice{ get; set; }
//
//		public Menu(){}
//
//		public Menu(....overloaded...){.....}
//  }
Create a MenuRepository Class that has methods needed.
//	Methods:
//		CreateNewMenuItem
//		DeleteMenuItem
//		ListAllMenuItems
//		ShowRequestedMenuItem (I'll have the #5)
Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.
//	CafeMenuProgram - provides a menu of options and calls methods based on menu options selected.
//	Alternatively: creates a new instance of CafeMenuProgramUI - calls UI.Run
//	CafeMenuProgramUI - 
 

Notes:
We don't need to be able to update items right now.

  

======================

Challenge 2: Claims

Komodo Claims Department
Komodo has a bug in its software and needs some new code.

The Claim has the following properties:
ClaimID
ClaimType
Description
ClaimAmount
DateOfIncident
DateOfClaim
IsValid
Komodo allows an insurance claim to be made up to 30 days after an incident took place. If the claim is not in the proper time limit, it is not valid.

A ClaimType could be the following:
Car
Home
Theft
 

The app will need methods to do the following:
Show a claims agent a menu:
Choose a menu item:
1. See all claims
2. Take care of next claim
3. Enter a new claim
For #1, a claims agent could see all items in the queue listed out like this:

ClaimID	Type	Description	Amount	DateOfAccident	DateOfClaim	IsValid
1	Car	Car accident on 465.	$400.00	4/25/18	4/27/18	true
2	Home	House fire in kitchen.	$4000.00	4/11/18	4/12/18	true
3	Theft	Stolen pancakes.	$4.00	4/27/18	6/01/18	false
For #2, when a claims agent needs to deal with an item they see the next item in the queue.

Here are the details for the next claim to be handled:
ClaimID: 1
Type: Car
Description: Car Accident on 464.
Amount: $400.00
DateOfAccident: 4/25/18
DateOfClaim: 4/27/18
IsValid: True
Do you want to deal with this claim now(y/n)? y
When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.

For #3, when a claims agent enters new data about a claim they will be prompted for questions about it:

Enter the claim id: 4
Enter the claim type: Car
Enter a claim description: Wreck on I-70.
Amount of Damage: $2000.00
Date Of Accident: 4/27/18
Date of Claim: 4/28/18
This claim is valid.
 

I accomplished the following:
1. Create a Claim class with properties, constructors, and any necessary fields.
2. Create a ClaimRepository class that has proper methods.
3. Create a Test Class for your repository methods.
4. Create a Program file that allows a claims manager to manage items in a list of claims.
 
 =======================

