using DoctorAppointmentBookingSys.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoctorAppointmentBookingSys.Controllers
{
    [AllowAnonymous] //To make access to login universally available.
    public class SecurityController : Controller
    {
        Context context = new Context();


        [HttpGet]
        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginIndex(User user)
        {
            var u = context.Users.Where(x => x.UserName == user.UserName && x.UserPass == user.UserPass).FirstOrDefault();
            if (u != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Messsage = "Invalid user. User Name or Password is incorrect.";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginIndex");
        }
    }
}