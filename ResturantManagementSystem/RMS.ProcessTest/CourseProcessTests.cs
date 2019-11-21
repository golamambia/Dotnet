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
    public class CourseProcessTests
    {
        [TestMethod()]
        public void GetAllCourseTest()
        {
            List<CourseModel> response = CourseProcess.GetAllCourse();
            Assert.AreEqual(response.Count() > 0, true);
        }

        [TestMethod()]
        public void GetCuisineIdTest()
        {
            CourseModel response = CourseProcess.GetCourseById(1);
            Assert.AreEqual(response != null, true);
        }

        [TestMethod()]
        public void GetByNameTest()
        {
            List<CourseModel> response = CourseProcess.GetByName("Main");
            Assert.AreEqual(response.Count() > 0, true);

        }

        [TestMethod()]
        public void GetCuisineIdTest1()
        {
            List<CourseModel> response = CourseProcess.GetCuisineId(2);
            Assert.AreEqual(response.Count() > 0, true);
        }

        [TestMethod()]
        public void AddCourseTest()
        {
            CourseModel courseModel = CourseProcess.AddCourse("Abc", "abc", "longcontent", "shortcontent", "user1", "uid");
            Assert.AreEqual(courseModel.Id > 0, true);
        }

        [TestMethod()]
        public void UpdateCourseTest()
        {
            CourseModel courseModel = CourseProcess.UpdateCourse(3, "Golam", "abc description", "longcontent", "shortcontent", "user1", "uid", true, true);

            Assert.AreEqual(courseModel.Id>0, true);
        }
    }
}