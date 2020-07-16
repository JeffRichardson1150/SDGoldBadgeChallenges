using System;
using System.Collections.Generic;
using AccessBadges_Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccessBadges_UnitTest
{
    [TestClass]
    public class AccessBadgeTests
    {
        public AccessBadgesRepository accessBadgeRepo = new AccessBadgesRepository();

        [TestMethod]
        public void AddNewBadgeToDirectory_ShouldReturnTrue()
        {
            // Arrange
            int badgeID = 1028;
            List<string> listOfDoors = new List<string>();
            listOfDoors.Add("A1");
            listOfDoors.Add("B2");
            listOfDoors.Add("C3");
            // Act
            bool addedToDirectory = accessBadgeRepo.AddNewBadgeToDirectory(badgeID, listOfDoors);

            // Assert
            Assert.IsTrue(addedToDirectory);
        }

        [TestMethod]
        public void AddNewBadgeToDirectory_ShouldReturnTrueFalse()
        {
            // Arrange
            int badgeID = 1028;
            List<string> listOfDoors = new List<string>();
            listOfDoors.Add("A1");
            listOfDoors.Add("B2");
            listOfDoors.Add("C3");
            // Act 
            bool firstAddedToDirectory = accessBadgeRepo.AddNewBadgeToDirectory(badgeID, listOfDoors);

            // Assert
            Assert.IsTrue(firstAddedToDirectory);

            // Act - try to add the badge ID twice so it returns a false on the second
            bool secondAddedToDirectory = accessBadgeRepo.AddNewBadgeToDirectory(badgeID, listOfDoors);

            // Assert
            Assert.IsFalse(secondAddedToDirectory);
        }

        public void AddNewBadgeToList_ShouldReturnTrue()
        {
            // Arrange
            int badgeID = 1028;
            EmployeeType employeeType = EmployeeType.IT;
            string employeeFirstName = "Jeff";
            string employeeLastName = "Richardson";
            List<string> listOfDoors = new List<string>();
            listOfDoors.Add("A1");
            listOfDoors.Add("B2");
            listOfDoors.Add("C3");

            // Act
            bool addedToList = accessBadgeRepo.AddNewBadgeToList(badgeID, employeeType, employeeFirstName, employeeLastName, listOfDoors);

            // Assert
            Assert.IsTrue(addedToList);
        }

        [TestMethod]
        public void ChangeDoorAccessForABadge_ShouldReturnTrue()
        {
            // Arrange
            int badgeID = 1028;
            EmployeeType employeeType = EmployeeType.IT;
            string employeeFirstName = "Jeff";
            string employeeLastName = "Richardson";
            List<string> listOfDoors = new List<string>();
            listOfDoors.Add("A1");
            listOfDoors.Add("B2");
            listOfDoors.Add("C3");

            bool addedToList = accessBadgeRepo.AddNewBadgeToList(badgeID, employeeType, employeeFirstName, employeeLastName, listOfDoors);

            // Assert
            Assert.IsTrue(addedToList);


            // Act
            listOfDoors.Add("C3"); // more Arrange
            bool doorListChanged = accessBadgeRepo.ChangeDoorAccessForABadge(badgeID, listOfDoors);

            // Assert
            Assert.IsTrue(doorListChanged);

        }
    }
}
