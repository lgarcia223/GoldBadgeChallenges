using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_01;

namespace Challenge_01_Tests
{
    [TestClass]
    public class KomodoMenuTest
    { 
        KomodoRepository _komodoRepo;
         KomodoMenu _emptyItem;
    
        [TestInitialize]
        public void Arrange()
        {
            _komodoRepo = new KomodoRepository();
            _emptyItem = new KomodoMenu();
        }

        [TestMethod]
        public void KomodoRepo_GetMenuItem_ShouldReturnCorrectCount()
        {
            var menuList = _komodoRepo.GetKomodoMenu();

            var expected = 0;
            var actual = menuList.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void KomodoRepo_AddMenuItem_ShouldReturnCorrectCount()
        {
            var menuList = _komodoRepo.GetKomodoMenu();
            _komodoRepo.AddItemToList(_emptyItem);

            var expected = 1;
            var actual = menuList.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void KomodoRepo_RemoveItemFromList_ShouldReturnCorrectCount()
        {
            var item = new KomodoMenu();
            var menuList = _komodoRepo.GetKomodoMenu();
            _komodoRepo.AddItemToList(item);
            _komodoRepo.RemoveItemFromList(item);

            var actual = menuList.Count;
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}
