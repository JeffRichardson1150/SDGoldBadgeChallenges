using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessBadges_Class
{
    public class AccessBadgesRepository
    {
        // a dictionary with key=BadgeID, content=list of door names
        Dictionary<int, List<string> > accessBadgeDictionary = new Dictionary<int, List<string>>();  // BadgeID, List of Door Names

        // a list of all employees and their access badges
        List<AccessBadge> accessBadgeList = new List<AccessBadge>();


        public bool AddNewBadgeToDirectory(int badgeID, List<string> listOfDoors)
        {
            try
            {
                accessBadgeDictionary.Add(badgeID, listOfDoors);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool AddNewBadgeToList(int badgeID, EmployeeType employeeType, string employeeFirstName, string employeeLastName, List<string> listOfDoors)
        {
            AccessBadge newAccessBadge = new AccessBadge(badgeID, employeeType, employeeFirstName, employeeLastName, listOfDoors);
            accessBadgeList.Add(newAccessBadge);
            return true;
        }

        public bool CheckWhetherBadgeIDExists(int badgeID)
        {
            // check whether the dictionary of keys contains the badge ID
            return accessBadgeDictionary.ContainsKey(badgeID);
        }

        public bool ChangeDoorAccessForABadge(int badgeID, List<string> newListOfDoors)
        {
            // if the badge ID exists in the dictionary, the corresponding list of doors will be changed to the new list
            // if the badge doesn't exist, it will create a new key/value pair
            accessBadgeDictionary[badgeID] = newListOfDoors;
            return accessBadgeDictionary.ContainsKey(badgeID);



        }
    }
}
