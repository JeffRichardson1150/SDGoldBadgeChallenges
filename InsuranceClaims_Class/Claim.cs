using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims_Class
{
    public enum ClaimType
    {
        Car =1,
        Home,
        Theft
    }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                // Komodo allows an insurance claim to be made up to 30 days after an incident took place. If the claim is not in the proper time limit, it is not valid.
                TimeSpan timeSinceIncident = DateOfClaim - DateOfIncident;
                double daysSinceIncident = timeSinceIncident.TotalDays;

                return (daysSinceIncident <= 30);

            }
        }

        public Claim()
        {

        }

        public Claim(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
