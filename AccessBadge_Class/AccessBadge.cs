using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessBadge_Class
{
    public class AccessBadge
    {
        public int BadgeID { get; set; }
        public List<string> ListOfStrings { get; set; }

        public AccessBadge()
        {

        }

        public AccessBadge(int badgeID, List<string> listOfStrings)
        {
            BadgeID = badgeID;
            ListOfStrings = listOfStrings;
        }
    }
}
