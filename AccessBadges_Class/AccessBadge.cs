using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessBadges_Class
{
    public enum EmployeeType
    {
        CXO,
        VP,
        Manager,
        IT,
        CustomerService,
        Sales,
        Accounting,
        HR
    }
    public enum BadgeType
    {
        A,
        B1,
        B2,
        B3,
        C1,
        C2
    }
    public class AccessBadge
    {
        public int BadgeID { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeName
        {
            get
            {
                return $"{EmployeeFirstName} {EmployeeLastName}";
            }
        }
        public List<string> ListOfDoors { get; set; }
        public AccessBadge() { }

        public AccessBadge(int badgeID, EmployeeType employeeType, string employeeFirstName, string employeeLastName, List<string> listOfDoors)
        {
            BadgeID = badgeID;
            EmployeeType = employeeType;
            EmployeeFirstName = employeeFirstName;
            EmployeeLastName = employeeLastName;
            ListOfDoors = listOfDoors;
        }
    }
}
