using System;
using Challenge_04;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_04_Tests
{
    [TestClass]
    public class KomodoBadgesTest
    {
        KBadgesRepository _kBadgeRepo;
        KomodoBadge _emptybadge;

        [TestInitialize]
        public void Arrange()
        {
            _kBadgeRepo = new KBadgesRepository();
            _emptybadge = new KomodoBadge();
            
        }

        [TestMethod]
        public void KBadgeRepo_GetList_ShouldReturnCorrectCount()
        {
            var doorList = _kBadgeRepo.GetList();

            var expected = 0;
            var actual = doorList.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void KBadgeRepo_AddDoorToList_ShouldReturnCorrectCout()
        {

            var doorList = _kBadgeRepo.GetList();
            _kBadgeRepo.AddDoortoList(_emptybadge);

        }

        //Sorry, this is as far as I can go with the time and understanding I have :-(
    }
}
