using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMS.Model;
using RMS.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Process.Tests
{
    [TestClass()]
    public class MenuProcessTests
    {
        [TestMethod()]
        public void GetAllMenuTest()
        {
            List<MenuModel> response = MenuProcess.GetAllMenu();
            Assert.AreEqual(response.Count() > 0, true);
        }

        [TestMethod()]
        public void GetMenuByIdTest()
        {
            MenuModel response = MenuProcess.GetMenuById(2);
            Assert.AreEqual(response != null, true);
        }

        [TestMethod()]
        public void GetMenuByNameTest()
        {
            List<MenuModel> response = MenuProcess.GetMenuByName("Test1");
            Assert.AreEqual(response.Count() > 0, true);
        }

        [TestMethod()]
        public void GetMenuByCourseIdTest()
        {
            List<MenuModel> response = MenuProcess.GetMenuByCourseId(1);
            Assert.AreEqual(response.Count() > 0, true);
        }

        [TestMethod()]
        public void GetMenuByCuisineIdTest()
        {
            List<MenuModel> response = MenuProcess.GetMenuByCuisineId(2);
            Assert.AreEqual(response.Count() > 0, true);
        }

        [TestMethod()]
        public void AddMenuTest()
        {
            MenuModel menuModel = MenuProcess.AddMenu("Abc2", "abc", "longcontent", "shortcontent", "user1", "uid", 2003, 3);
            Assert.AreEqual(menuModel.Id > 0, true);
        }

        [TestMethod()]
        public void UpdateMenuTest()
        {
            MenuModel menuModel = MenuProcess.UpdateMenu(1004, "Golam", "abc description", "longcontent", "shortcontent", "user1", "uid", true, true, 3,4);

            Assert.AreEqual(menuModel.Id > 0, true);
        }
    }
}