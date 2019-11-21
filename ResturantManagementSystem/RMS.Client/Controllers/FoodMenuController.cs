using RMS.Model;
using RMS.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMS.Client.Controllers
{
    public class FoodMenuController : Controller
    {
        // GET: FoodMenu
        public ActionResult Index()
        {
            List<MenuModel> menus= MenuProcess.GetAllMenu();
            return View(menus);
        }

        // GET: FoodMenu/Details/5
        public ActionResult Details(int id)
        {
            MenuModel menu = MenuProcess.GetMenuById(id);
            return View(menu);
        }

        // GET: FoodMenu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodMenu/Create
        [HttpPost]
        public ActionResult Create(MenuModel model)
        {
            try
            {
                // TODO: Add insert logic here
                MenuProcess.AddMenu(model.Name,model.Description.Title,model.Description.LongContent,model.Description.ShortContent,"abc","abc2",3,4);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodMenu/Edit/5
        public ActionResult Edit(int id)
        {
            MenuModel menu = MenuProcess.GetMenuById(id);
            return View(menu);
        }

        // POST: FoodMenu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MenuModel model)
        {
            try
            {
                if (ModelState.IsValid && id == model.Id)
                {
                    MenuProcess.UpdateMenu(model.Id, model.Name,model.Description.
                       Title, model.Description.LongContent, model.Description.ShortContent
                       , "amb", "1234", true, true,2,2
                       );
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodMenu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FoodMenu/Delete/5
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
