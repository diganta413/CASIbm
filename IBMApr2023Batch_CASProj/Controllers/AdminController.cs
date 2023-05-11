using IBM_CAS.Models.SecuritydbModel;
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
        Models.SecuritydbModel.ClinicAutomationSystemIBMEntities _db = new Models.SecuritydbModel.ClinicAutomationSystemIBMEntities ();

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
        public ActionResult AddNewDoctor(Models.SecuritydbModel.Doctor doctor)
        {
            Models.SecuritydbModel.User user = new Models.SecuritydbModel.User
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
        public ActionResult AddNewPatient(Models.SecuritydbModel.Patient patient)
        {
            Models.SecuritydbModel.User user = new Models.SecuritydbModel.User
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
        public ActionResult AddNewSupplier(Models.SecuritydbModel.Supplier supplier)
        {
            Models.SecuritydbModel.User user = new Models.SecuritydbModel.User
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
        public ActionResult AddNewSalesman(Models.SecuritydbModel.Salesman salesman)
        {
            Models.SecuritydbModel.User user = new Models.SecuritydbModel.User
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
