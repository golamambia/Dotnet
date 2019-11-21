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
    public class CommonControllerMethods : Controller
    {
       public static string CheckActive(string controller, string action)
        {
            if (controller=="Settings" && action== "EntryList")
            {
                return "active";
            }
            else
            {
                return "";
            }
        }

    }
}
