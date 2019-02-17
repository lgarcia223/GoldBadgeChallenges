using System;
using Challenge_02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_02_Tests
{
    [TestClass]
    public class KClaimsTest
    {
        KClaimsRepository _kClaimsRepo;
        KClaims _emptyClaim;

        [TestInitialize]
        public void Arrange()
        {
            _kClaimsRepo = new KClaimsRepository();
            _emptyClaim = new KClaims();
        }

        [TestMethod]
        public void KClaimsRepo_SeeClaimList_ShouldReturnCorrectCount()
        {
            var claimList = _kClaimsRepo.SeeClaimList();

            var expected = 0;
            var actual = claimList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KClaimsRepo_AddClaimToList_ShouldReturnCorrectCount()
        {
            var claimList = _kClaimsRepo.SeeClaimList();
            _kClaimsRepo.AddClaimToList(_emptyClaim);

            var expected = 1;
            var actual = claimList.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KClaimsRepo__GetClaimQueue_ShouldReturnCorrectCount()
        {
            var claimQueue = _kClaimsRepo.GetClaimQueue();

            var expected = 0;
            var actual = claimQueue.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KClaimsRepo_ResolveNextClaim_ShouldReturnCorrectCount()
        {
            var claimQueue = _kClaimsRepo.GetClaimQueue();
            _kClaimsRepo.AddContentToQueue(_emptyClaim);
            _kClaimsRepo.ResolveNextClaim();

            var actual = claimQueue.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KClaimsRepo_AddContentToQueue_ShouldReturnCorrectCount()
        {
            var claimQueue = _kClaimsRepo.GetClaimQueue();
            _kClaimsRepo.AddContentToQueue(_emptyClaim);

            var actual = claimQueue.Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }
        [DataTestMethod]
        [DataRow (1, ClaimType.Car)]
        [DataRow (2, ClaimType.Home)]
        [DataRow (3, ClaimType.Theft)]
        public void KClaimsRepo_GetTypeFromInt_ShouldReturnCorrectType(int typeInput, ClaimType expected)
        {
            var actual = _kClaimsRepo.GetTypeFromInt(typeInput);

            Assert.AreEqual(expected, actual);
        }

    }
}
