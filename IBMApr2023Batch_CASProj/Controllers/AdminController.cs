using IBMApr2023Batch_CASProj.Models.SecurityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IBM_CAS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IBMApr2023Batch_CASProj.Models.SecurityModel.CASIbmEntities _db = new IBMApr2023Batch_CASProj.Models.SecurityModel.CASIbmEntities();

        // GET: Admin

        public ActionResult Index()
        {
            return View();
        }
        // GET: Doctor
        public ActionResult ListDoctor()
        {
            return View(_db.Doctors.Include("User").ToList());
        }
        public ActionResult AddNewDoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewDoctor(IBMApr2023Batch_CASProj.Models.SecurityModel.Doctor doctor)
        {
            IBMApr2023Batch_CASProj.Models.SecurityModel.User user = new IBMApr2023Batch_CASProj.Models.SecurityModel.User
            {
                UserName = "Doc" + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                UserPassword = DateTime.Now.ToString("ddmmyyyyhhmmss"),
                UserRole="DOCTOR",
                LoginStatus="ACTIVE",
            };
            doctor.User = user;
            doctor.DoctorStatus = "ACTIVE";
            _db.Doctors.Add(doctor);
            _db.SaveChanges();
            return RedirectToAction("Index","Admin");

        }
        //    public ActionResult EditDoctor(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Doctor doctor = _db.Doctors.Find(id);
        //        if (doctor == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(doctor);

        //    }
        //    [HttpPost]
        //    public ActionResult EditDoctor(Models.SecuritydbModel.Doctor doctor)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _db.Entry(doctor).State = EntityState.Modified;
        //            _db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(doctor);
        //    }

        public ActionResult ListPatient()
        {
            return View(_db.Patients.Include("User").ToList());
        }
        public ActionResult AddNewPatient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewPatient(IBMApr2023Batch_CASProj.Models.SecurityModel.Patient patient)
        {
            IBMApr2023Batch_CASProj.Models.SecurityModel.User user = new IBMApr2023Batch_CASProj.Models.SecurityModel.User
            {
                UserName = "Pat" + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                UserPassword = DateTime.Now.ToString("ddmmyyyyhhmmss"),
                UserRole = "PATIENT",
                LoginStatus = "ACTIVE",
            };
            patient.User = user;
            //patient.Patient = "ACTIVE";
            
            _db.Patients.Add(patient);
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");

        }
        public ActionResult ListSupplier()
        {
            return View(_db.Suppliers.Include("User").ToList());
        }
        public ActionResult AddNewSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewSupplier(IBMApr2023Batch_CASProj.Models.SecurityModel.Supplier supplier)
        {
            IBMApr2023Batch_CASProj.Models.SecurityModel.User user = new IBMApr2023Batch_CASProj.Models.SecurityModel.User
            {
                UserName = "Sup" + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                UserPassword = DateTime.Now.ToString("ddmmyyyyhhmmss"),
                UserRole = "SUPPLIER",
                LoginStatus = "ACTIVE",
            };
            supplier.User = user;
            //patient.Patient = "ACTIVE";
            _db.Suppliers.Add(supplier);
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");

        }
        public ActionResult ListSalesman()
        {
            return View(_db.Salesmen.Include("User").ToList());
        }
        public ActionResult AddNewSalesman()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewSalesman(IBMApr2023Batch_CASProj.Models.SecurityModel.Salesman salesman)
        {
            IBMApr2023Batch_CASProj.Models.SecurityModel.User user = new IBMApr2023Batch_CASProj.Models.SecurityModel.User
            {
                UserName = "Sal" + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                UserPassword = DateTime.Now.ToString("ddmmyyyyhhmmss"),
                UserRole = "SALESMAN",
                LoginStatus = "ACTIVE",
            };
            salesman.User = user;
            
            _db.Salesmen.Add(salesman);
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");

        }


    }
}
