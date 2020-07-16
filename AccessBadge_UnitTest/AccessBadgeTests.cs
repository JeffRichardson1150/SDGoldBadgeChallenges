using System;
using System.Collections.Generic;
using AccessBadge_Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccessBadge_UnitTest
{
    [TestClass]
    public class AccessBadgeTests
    {
        AccessBadgeRepository _repo = new AccessBadgeRepository();

        [TestMethod]
        public void CreateNewBadge_ShouldReturnTrue()
        {
            // Arrange
            int badgeID = 1234;
            List<string> listOfDoors = new List<string>();
            // Act
            bool created = _repo.CreateNewBadge(badgeID, listOfDoors);
            // Assert
            Assert.IsTrue(created);
        }

        [TestMethod]
        public void AddDoorToList_ShouldReturnTrue()
        {
            // Arrange
            CreateNewBadge_ShouldReturnTrue();
            int badgeID = 1234;
            string door = "A1";

            // Act
            bool added = _repo.AddDoorToList(badgeID, door);

            // Assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void CheckWhetherBadgeIDExists_ShouldReturnTrue()
        {
            // Arrange
            AddDoorToList_ShouldReturnTrue();
            int badgeID = 1234;

            // Act
            bool exists = _repo.CheckWhetherBadgeIDExists(badgeID);

            // Assert
            Assert.IsTrue(exists);
        }
    }
}
