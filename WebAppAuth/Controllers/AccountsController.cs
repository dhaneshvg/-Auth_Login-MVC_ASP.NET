using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppAuth.Models;
using System.Data;

namespace WebAppAuth.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (DBEntities db=new DBEntities())
            {
                var result = db.UserMasters.Where(x => x.UserId==user.Username && x.Password==user.Password);
                if (result.Count()!=0)
                {
                    Session["userid"] = user.Username;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["msg"] = "Incorect UserId/Password";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return View("Login");
        }
    }
}
 