using System;
using System.Collections.Generic;
using InsuranceClaims_Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsuranceClaims_UnitTest
{
    [TestClass]
    public class InsuranceClaimsTests
    {
        [TestMethod]
        public void GetAllClaims_ShouldGetQueueOfAllClaims()
        {
            // Arrange
            ClaimsRepository _claimsRepo = new ClaimsRepository();

            Claim seedClaim1 = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim seedClaim2 = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim seedClaim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));

            _claimsRepo.AddClaimToQueue(seedClaim1);
            _claimsRepo.AddClaimToQueue(seedClaim2);
            _claimsRepo.AddClaimToQueue(seedClaim3);

            // Act
            Queue<Claim> allClaims = _claimsRepo.GetAllClaims();

            // Assert
            Assert.AreEqual(allClaims.Count, 3);
            Assert.AreSame(allClaims.Peek(), seedClaim1);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            //Claim peekClaim = _claimQueue();
        }
    }
}
