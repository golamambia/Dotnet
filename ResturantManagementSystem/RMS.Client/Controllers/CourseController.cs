using RMS.Client.Models;
using RMS.Model;
using RMS.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Client.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            List<CourseModel> courses = CourseProcess.GetAllCourse();
            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            CourseModel course = CourseProcess.GetCourseById(id);
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            CourseViewModel courseViewModel = new CourseViewModel();
            courseViewModel.Cuisines = CuisineProcess.GetAllCuisine();
                return View(courseViewModel);
            
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(CourseViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                CourseProcess.AddCourse(model.Course.Name, model.Course.Description.Title, model.Course.Description.LongContent, model.Course.Description.ShortContent, "abc", "a123",model
                    .Course.Cuisine.Id);
            
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            //CourseModel course = CourseProcess.GetCourseById(id);
            CourseViewModel courseViewModel = new CourseViewModel();
            courseViewModel.Cuisines = CuisineProcess.GetAllCuisine();
            courseViewModel.Course = CourseProcess.GetCourseById(id); 
            return View(courseViewModel);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseViewModel model)
        {
            try
            {
                if (ModelState.IsValid && id == model.Course.Id)
                {
                    CourseProcess.UpdateCourse(model.Course.Id, model.Course.Name, model.Course.Description.
                       Title, model.Course.Description.LongContent, model.Course.Description.ShortContent
                       , "amb","1234", model.Course.IsActive,true,model.Course.Cuisine.Id
                       );
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
