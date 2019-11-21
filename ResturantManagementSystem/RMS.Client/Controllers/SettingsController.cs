using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMS.Model;
using RMS.Client.Models;
using RMS.Process;

namespace RMS.Client.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Profile()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Profile(CourseModel model)
        {
            return View();
        }

        public ActionResult Register()
        {
            if (TempData["ResponseMessage"] != null)
            {
                ViewBag.ResponseMessage = Convert.ToString(TempData["ResponseMessage"]);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationModel model)
        { 
            if (ModelState.IsValid)
            {

                RegistrationModel registrationModel = RegisterProcess.AddRegistration(model.Name, model.Email, model.CreatedByUserName, model.CreatedByUserId, model.IsActive);
                if(registrationModel.ExceptionKey==ExceptionKey.Success)
                {
                    ModelState.Clear();
                    ViewBag.ResponseMessage = "Record inserted successfully";
                    //return View(model);
                    TempData["ResponseMessage"]= "Record inserted successfully";
                    return RedirectToAction("Register");
                }
                else
                {
                    ModelState.AddModelError("", registrationModel.DetailResponseMessage);
                    return View(model);
                }
            }
            return View(model);
        }

        public ActionResult Reg_edit(int id)
        {
            RegistrationModel responce = RegisterProcess.GetRegById(id);

            return View(responce);
        }
        [HttpPost]
        public JsonResult GetMail(RegistrationModel model)
        {
            RegistrationModel responce = RegisterProcess.GetRegByEmail(model.Email);

            if (responce.Id>0)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
            
        }

        [HttpPost]
        public ActionResult Reg_edit(int id, RegistrationModel model)
        {
            try
            {
                if (ModelState.IsValid && id == model.Id)
                {
                    RegistrationModel registerModel = RegisterProcess.UpdateRegistration(id, model.Name, model.Email, model.CreatedByUserName, model.CreatedByUserId, model.IsActive);

                    if (registerModel.ExceptionKey == ExceptionKey.Success)
                    {
                        ViewBag.ResponseMessage = "Record updated successfully";
                    }
                    else
                    {
                        ViewBag.ResponseMessage = "Record updated failed!";
                    }
                   
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();

            }
        }

        public ActionResult EntryList()
        {
            List<RegistrationModel> responce = RegisterProcess.GetAll();
            if (TempData["ResponseMessage"] != null)
            {
                ViewBag.ResponseMessage = Convert.ToString(TempData["ResponseMessage"]);
            }
            return View(responce);
        }

        public ActionResult Reg_del(int id)
        {
            RegistrationModel responce = RegisterProcess.GetRegById(id);
            try {
                if (responce.Id>0)
                {
                    RegistrationModel registerModel = RegisterProcess.UpdateRegistration(id, responce.Name, responce.Email, responce.CreatedByUserName, responce.CreatedByUserId, false);

                    if (registerModel.ExceptionKey == ExceptionKey.Success)
                    {
                        TempData["ResponseMessage"] = "Record deleted successfully";
                    }
                    else
                    {
                        TempData["ResponseMessage"] = "Record delete failed!";
                    }

                }
                else
                {
                    TempData["ResponseMessage"] = "Sorry try again!";
                }
                //return View();
                return RedirectToAction("EntryList");
            }
            catch(Exception ex)
            {
                return RedirectToAction("EntryList"); 
            }
            
        }


    }
}