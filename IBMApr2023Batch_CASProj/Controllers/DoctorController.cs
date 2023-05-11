using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IBM_CAS.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        Models.SecuritydbModel.ClinicAutomationSystemIBMEntities _db = new Models.SecuritydbModel.ClinicAutomationSystemIBMEntities();
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.SecuritydbModel.Doctor doctor)
        {
            Models.SecuritydbModel.User user = new Models.SecuritydbModel.User
            {
                UserName = "Doc" + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                UserPassword = DateTime.Now.ToString("ddmmyyyyhhmmss")
            };
            doctor.User = user;
            _db.Doctors.Add(doctor);
            _db.SaveChanges();
            return View();
        }
    }
    
    
}