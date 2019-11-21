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
    public class CuisineProcessTests
    {
        [TestMethod()]
        public void GetAllCuisineTest()
        {
            List<CuisineModel> response = CuisineProcess.GetAllCuisine();
            Assert.AreEqual(response.Count() > 0, true);
        }

        [TestMethod()]
        public void GetCuisineByIdTest()
        {
            CuisineModel response = CuisineProcess.GetCuisineById(2);
            Assert.AreEqual(response != null, true);
        }

        [TestMethod()]
        public void GetCuisineByNameTest()
        {
            List<CuisineModel> response = CuisineProcess.GetCuisineByName("Cuisine2");
            Assert.AreEqual(response.Count() > 0, true);
        }

        [TestMethod()]
        public void AddCuisineTest()
        {
            CuisineModel cuisineModel = CuisineProcess.AddCuisine("Abc", "abc", "longcontent", "shortcontent", "user1", "uid");

            Assert.AreEqual(cuisineModel.Id > 0, true);
        }

        [TestMethod()]
        public void UpdateCuisineTest()
        {
            CuisineModel cuisineModel = CuisineProcess.UpdateCuisine(1002,"Golam", "abc description", "longcontent", "shortcontent", "user1", "uid",true,true);

            Assert.AreEqual(cuisineModel.Id > 0, true);
        }
    }
}