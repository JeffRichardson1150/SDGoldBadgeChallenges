using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeMenu_Class;
using System.Collections.Generic;

namespace CafeMenu_UnitTest
{
    [TestClass]
    public class CafeMenuTests
    {
        [TestInitialize]
        public void InitializeTests()
        {
            // ?????????  Is this running before each test  ?????????
            CafeMenuRepository _cafeMenuRepo = new CafeMenuRepository();
            List<MenuItem> allMenuItemsDeleted = _cafeMenuRepo.DeleteAllMenuItems();
            // seed the repository with menu items with this constructor
            // public MenuItem(int mealNumber, string mealName, string mealDescription, string mealIngredients, decimal mealPrice) 

            MenuItem seedMenuItem1 = new MenuItem(1, "Meal One", "The first meal on the menu", "One burger, One bun, One whiskey", 11.11m);
            MenuItem seedMenuItem2 = new MenuItem(2, "Meal Two", "The second meal on the menu", "Two burgers, Two buns, Two whiskeys", 22.22m);
            MenuItem seedMenuItem3 = new MenuItem(3, "Meal Three", "The third meal on the menu", "Three burgers, Three buns, Three whiskeys", 33.33m);
            MenuItem seedMenuItem4 = new MenuItem(4, "Meal Four", "The fourth meal on the menu", "Four burgers, Four buns, Four whiskeys", 44.44m);

            _cafeMenuRepo.AddItemToMenu(seedMenuItem1);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem2);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem3);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem4);
        }

        [TestMethod]
        public void AddItemToMenu_ShouldReturnTrue()
        {
            CafeMenuRepository _cafeMenuRepo = new CafeMenuRepository();

            // Arrange
            MenuItem seedMenuItem5 = new MenuItem(5, "Meal Five", "The fifth meal on the menu", "Five burgers, Five buns, Five whiskeys", 55.55m);

            // Act
            bool addItemToMenu = _cafeMenuRepo.AddItemToMenu(seedMenuItem5);

            // Assert
            Assert.IsTrue(addItemToMenu);
        }

        [TestMethod]
        public void GetMenuItemByMealNumber_ShouldReturnRequestedMenuItem()
        {
            CafeMenuRepository _cafeMenuRepo = new CafeMenuRepository();

            // Arrange
            //   seed the menu list
            MenuItem seedMenuItem1 = new MenuItem(1, "Meal One", "The first meal on the menu", "One burger, One bun, One whiskey", 11.11m);
            MenuItem seedMenuItem2 = new MenuItem(2, "Meal Two", "The second meal on the menu", "Two burgers, Two buns, Two whiskeys", 22.22m);
            MenuItem seedMenuItem3 = new MenuItem(3, "Meal Three", "The third meal on the menu", "Three burgers, Three buns, Three whiskeys", 33.33m);
            MenuItem seedMenuItem4 = new MenuItem(4, "Meal Four", "The fourth meal on the menu", "Four burgers, Four buns, Four whiskeys", 44.44m);

            _cafeMenuRepo.AddItemToMenu(seedMenuItem1);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem2);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem3);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem4);

            // Act
            MenuItem menuItem = _cafeMenuRepo.GetMenuItemByMealNumber(3);

            // Assert
            Assert.AreEqual(menuItem, seedMenuItem3);

        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            CafeMenuRepository _cafeMenuRepo = new CafeMenuRepository();

            // Arrange
            //   seed the menu list
            MenuItem seedMenuItem1 = new MenuItem(1, "Meal One", "The first meal on the menu", "One burger, One bun, One whiskey", 11.11m);
            MenuItem seedMenuItem2 = new MenuItem(2, "Meal Two", "The second meal on the menu", "Two burgers, Two buns, Two whiskeys", 22.22m);
            MenuItem seedMenuItem3 = new MenuItem(3, "Meal Three", "The third meal on the menu", "Three burgers, Three buns, Three whiskeys", 33.33m);
            MenuItem seedMenuItem4 = new MenuItem(4, "Meal Four", "The fourth meal on the menu", "Four burgers, Four buns, Four whiskeys", 44.44m);

            _cafeMenuRepo.AddItemToMenu(seedMenuItem1);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem2);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem3);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem4);

            // get menu item 3 from the list
            MenuItem menuItem = _cafeMenuRepo.GetMenuItemByMealNumber(3);
            
            // Act
            //    delete menu item 3 from the list
            bool menuItemDeleted = _cafeMenuRepo.DeleteMenuItem(menuItem);
            
            // Assert
            Assert.IsTrue(menuItemDeleted);
        }

        [TestMethod]
        public void GetAllMenuItems_ShouldReturnMenuItemList()
        {
            CafeMenuRepository _cafeMenuRepo = new CafeMenuRepository();

            // Arrange
            // look in TestInitialize
            MenuItem seedMenuItem1 = new MenuItem(1, "Meal One", "The first meal on the menu", "One burger, One bun, One whiskey", 11.11m);
            MenuItem seedMenuItem2 = new MenuItem(1, "Meal Two", "The second meal on the menu", "Two burgers, Two buns, Two whiskeys", 22.22m);
            MenuItem seedMenuItem3 = new MenuItem(1, "Meal Three", "The third meal on the menu", "Three burgers, Three buns, Three whiskeys", 33.33m);
            MenuItem seedMenuItem4 = new MenuItem(1, "Meal Four", "The fourth meal on the menu", "Four burgers, Four buns, Four whiskeys", 44.44m);

            _cafeMenuRepo.AddItemToMenu(seedMenuItem1);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem2);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem3);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem4);


            // Act
            List<MenuItem> listOfAllItems = _cafeMenuRepo.GetAllMenuItems();

            // Assert
            Assert.AreEqual(listOfAllItems.Count, 4);
        }

        [TestMethod]
        public void DeleteAllMenuItems_ShouldReturnEmptyList()
        {
            CafeMenuRepository _cafeMenuRepo = new CafeMenuRepository();

            // Arrange
            // seed the repository with menu items with this constructor
            // public MenuItem(int mealNumber, string mealName, string mealDescription, string mealIngredients, decimal mealPrice) 

            MenuItem seedMenuItem1 = new MenuItem(1, "Meal One", "The first meal on the menu", "One burger, One bun, One whiskey", 11.11m);
            MenuItem seedMenuItem2 = new MenuItem(2, "Meal Two", "The second meal on the menu", "Two burgers, Two buns, Two whiskeys", 22.22m);
            MenuItem seedMenuItem3 = new MenuItem(3, "Meal Three", "The third meal on the menu", "Three burgers, Three buns, Three whiskeys", 33.33m);
            MenuItem seedMenuItem4 = new MenuItem(4, "Meal Four", "The fourth meal on the menu", "Four burgers, Four buns, Four whiskeys", 44.44m);

            _cafeMenuRepo.AddItemToMenu(seedMenuItem1);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem2);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem3);
            _cafeMenuRepo.AddItemToMenu(seedMenuItem4);

            // Act
            List<MenuItem> allMenuItemsDeleted = _cafeMenuRepo.DeleteAllMenuItems();

            // Assert
            Assert.AreEqual(allMenuItemsDeleted.Count, 0);
        }
    }
}
