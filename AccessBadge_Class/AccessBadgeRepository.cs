using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessBadge_Class
{
    public class AccessBadgeRepository
    {
        Dictionary<int, List<string>> accessBadgeDictionary = new Dictionary<int, List<string>>();  // BadgeID, List of Door Names

        public bool CreateNewBadge(int badgeID, List<string> listOfDoors)
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

        public bool AddDoorToList(int badgeID, string door)
        {
            accessBadgeDictionary[badgeID].Add(door);
            return CheckWhetherBadgeIDExists(badgeID);
        }

        public bool CheckWhetherBadgeIDExists(int badgeID)
        {
            // check whether the dictionary of keys contains the badge ID
            return accessBadgeDictionary.ContainsKey(badgeID);
        }

        public List<string> ReturnListOfDoors(int badgeID)
        {
            return accessBadgeDictionary[badgeID];
        }

        public bool RemoveDoorFromList(int badgeID, string door)
        {
            accessBadgeDictionary[badgeID].Remove(door);
            return (!accessBadgeDictionary[badgeID].Contains(door));
        }

        public Dictionary<int, List<string>> returnTotalDictionary()
        {
            return accessBadgeDictionary;
        }

    }
}
