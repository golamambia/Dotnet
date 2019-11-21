using RMS.Model;
using RMS.Process;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RMS.Client.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        public ActionResult Index()
        {
            List<CuisineModel> cuisine = CuisineProcess.GetAllCuisine();
            return View(cuisine);
        }

        // GET: Cuisine/Details/5
        public ActionResult Details(int id)
        {
            CuisineModel cuisine = CuisineProcess.GetCuisineById(id);
            return View(cuisine);
        }

        // GET: Cuisine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cuisine/Create
        [HttpPost]
        public ActionResult Create(CuisineModel model)
        {
            try
            {
                // TODO: Add insert logic here

                CuisineProcess.AddCuisine(model.Name,model.Description.Title,model.Description.LongContent,model.Description.ShortContent,"amb","1234");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuisine/Edit/5
        public ActionResult Edit(int id)
        {
            CuisineModel cuisine = CuisineProcess.GetCuisineById(id);
            return View(cuisine);
        }

        // POST: Cuisine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,CuisineModel model)
        {
            try
            {
                if(ModelState.IsValid&&id==model.Id)
                {
                    //model.Description = new DescriptionModel();
                    CuisineProcess.UpdateCuisine(id, model.Name, model.Description.Title, model.Description.LongContent, model.Description.ShortContent,"amb","1234", true, true);
                }

                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Cuisine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cuisine/Delete/5
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
