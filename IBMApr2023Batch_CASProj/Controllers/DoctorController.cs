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
        IBMApr2023Batch_CASProj.Models.SecurityModel.CASIbmEntities _db = new IBMApr2023Batch_CASProj.Models.SecurityModel.CASIbmEntities();
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
        public ActionResult Create(IBMApr2023Batch_CASProj.Models.SecurityModel.Doctor doctor)
        {
            IBMApr2023Batch_CASProj.Models.SecurityModel.User user = new IBMApr2023Batch_CASProj.Models.SecurityModel.User
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