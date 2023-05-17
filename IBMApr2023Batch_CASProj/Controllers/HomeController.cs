using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IBMApr2023Batch_CASProj.Models.SecurityModel;

namespace IBMApr2023Batch_CASProj.Controllers
{
    public class HomeController : Controller
    {
        IBMApr2023Batch_CASProj.Models.SecurityModel.CASIbmEntities _db = new IBMApr2023Batch_CASProj.Models.SecurityModel.CASIbmEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Drugs.ToList());
        }

public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(Models.LoginViewModel model)
        {
            using (Models.SecurityModel.CASIbmEntities  context = new Models.SecurityModel.CASIbmEntities() )
            {
               
                Models.SecurityModel.User usr = context.Users.FirstOrDefault(user => user.UserName.ToLower() ==
                     model.UserName.ToLower() && user.UserPassword == model.UserPassword);
                if (usr != null)
                {
                    
                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    return RedirectToAction("Index", usr.UserRole);
                    //if (usr.UserRole.ToUpper() == "ADMIN")
                    //    return RedirectToAction("INDEX", "ADMIN");
                    //else if (usr.UserRole.ToUpper() == "DOCTOR")
                    //    return RedirectToAction("Index", "Doctor");

                }
                ModelState.AddModelError("UserName", "Invalid Username or Password");
                return View(model);
            }
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }



    }
}