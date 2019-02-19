using System;
using Challenge_03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_03_Tests
{
    [TestClass]
    public class KOutingsTest
    {
        KOutingsRepository _kOutingsRepo;
        KOutings _emptyOuting;

        [TestInitialize]
        public void Arrange()
        {
            _kOutingsRepo = new KOutingsRepository();
            _emptyOuting = new KOutings();

        }
        [TestMethod]
        public void KOutingsRepo_GetOutingsList_ShouldReturnCorrectCount()
        {
            var outingsList = _kOutingsRepo.GetOutingsList();

            var expected = 0;
            var actual = outingsList.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void KOutingsRepo_AddOutingToList_ShouldReturnCorrectCount()
        {
            var outingsList = _kOutingsRepo.GetOutingsList();
            _kOutingsRepo.AddOutingToList(_emptyOuting);


            var expected = 1;
            var actual = outingsList.Count;

            Assert.AreEqual(expected, actual);
        }


        [DataTestMethod]
        [DataRow(1, OutingType.Golf)]
        [DataRow(2, OutingType.Bowling)]
        [DataRow(3, OutingType.AmusementPark)]
        [DataRow(4, OutingType.Concert)]
        [DataRow(5, OutingType.Other)]
        public void KOutingsRepo_GetTypefromInt_ShouldReturnCorrectTYpe(int typeInput, OutingType expected)
        {
            var actual = _kOutingsRepo.GetTypefromInt(typeInput);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void KOutingsRepository_OutingCostByType_ShouldReturnSumOfAll()
        {
            _kOutingsRepo.GetOutingsList();

            KOutings outing = new KOutings(OutingType.AmusementPark, 2, "", 3);
            KOutings outingTwo = new KOutings(OutingType.Bowling, 2, "", 3);
            KOutings outingThree = new KOutings(OutingType.AmusementPark, 2, "", 3);

            _kOutingsRepo.AddOutingToList(outing);
            _kOutingsRepo.AddOutingToList(outingTwo);
            _kOutingsRepo.AddOutingToList(outingThree);

            decimal actual = _kOutingsRepo.OutingCostByType(OutingType.AmusementPark);
            decimal actualTwo = _kOutingsRepo.OutingCostByType(OutingType.Bowling);

            decimal expected = 12m;
            decimal expectedTwo = 6m;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedTwo, actualTwo);
        }
    }
}
