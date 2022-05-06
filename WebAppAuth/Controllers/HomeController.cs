using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppAuth.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                if (Session["userid"] == null)
                {
                    return RedirectToAction("Login", "Accounts");
                }
            }
            catch
            {
                return RedirectToAction("Login", "Accounts");
            }
            return View();
        }
    }
}