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
            var viewModel = new IBMApr2023Batch_CASProj.Models.IndexViewModel()
            {
                Doctors = _db.Doctors.Include("User").ToList(),
                Patients = _db.Patients.Include("User").ToList(),
                Suppliers = _db.Suppliers.Include("User").ToList(),
                Salesmen = _db.Salesmen.Include("User").ToList(),
            };
            return View(viewModel);
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
        public ActionResult DoctorDetails(int? id)
        {
            var user = _db.Doctors.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = _db.Doctors.Find(id);

            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
            

        }
        public ActionResult EditDoctorViewList()
        {
            return View(_db.Doctors.Include("User").ToList());
        }
        public ActionResult EditDoctor(int? id)
        {
            var user = _db.Doctors.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = _db.Doctors.Find(id);
            
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);

            

        }
        [HttpPost]
        public ActionResult EditDoctor(IBMApr2023Batch_CASProj.Models.SecurityModel.Doctor doctor)
        {
            var existingDoctor = _db.Doctors.Find(doctor.DoctorId);
            IBMApr2023Batch_CASProj.Models.SecurityModel.User user = new IBMApr2023Batch_CASProj.Models.SecurityModel.User
            {
                UserName = existingDoctor.User.UserName,
                UserPassword = existingDoctor.User.UserPassword,
                UserRole = existingDoctor.User.UserRole,
                LoginStatus = existingDoctor.User.LoginStatus
            };



            doctor.User = user;
            existingDoctor.DoctorFirstName = doctor.DoctorFirstName;
            existingDoctor.DoctorLastName = doctor.DoctorLastName;
            existingDoctor.DoctorPhone = doctor.DoctorPhone;
            existingDoctor.DoctorDescription = doctor.DoctorDescription;
            existingDoctor.DoctorEmail = doctor.DoctorEmail;
            existingDoctor.DoctorSpec = doctor.DoctorSpec;
            
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");
            
            
            
            
            
        }
        
        public ActionResult DeleteDoctor(int? id)
        {
            var user = _db.Doctors.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = _db.Doctors.Find(id);

            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
            
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("DeleteDoctor")]
        public ActionResult DeleteDConfirmed(int id)
        {
            Doctor doctor = _db.Doctors.Find(id);
            _db.Doctors.Remove(doctor);
            _db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
        public ActionResult UpdateDoctorStatusViewList()
        {
            return View(_db.Doctors.Include("User").ToList());
        }
        public ActionResult UpdateDoctorStatus(int? id)
        {
            var user = _db.Doctors.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = _db.Doctors.Find(id);

            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);



        }
        [HttpPost]
        public ActionResult UpdateDoctorStatus(IBMApr2023Batch_CASProj.Models.SecurityModel.Doctor doctor)
        {
            var existingDoctor = _db.Doctors.Find(doctor.DoctorId);
            IBMApr2023Batch_CASProj.Models.SecurityModel.User user = new IBMApr2023Batch_CASProj.Models.SecurityModel.User
            {
                UserName = existingDoctor.User.UserName,
                UserPassword = existingDoctor.User.UserPassword,
                UserRole = existingDoctor.User.UserRole,
                LoginStatus = existingDoctor.User.LoginStatus,
                

            };


            doctor.User = user;
            existingDoctor.DoctorStatus = doctor.DoctorStatus;


            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");





        }

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
        public ActionResult PatientDetails(int? id)
        {
            var user = _db.Patients.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = _db.Patients.Find(id);

            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);


        }
        public ActionResult EditPatientViewList()
        {
            return View(_db.Patients.Include("User").ToList());
        }
        public ActionResult EditPatient(int? id)
        {
            var user = _db.Patients.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = _db.Patients.Find(id);

            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);



        }
        [HttpPost]
        public ActionResult EditPatient(IBMApr2023Batch_CASProj.Models.SecurityModel.Patient patient)
        {
            var existingPatient = _db.Patients.Find(patient.PatientId);
            IBMApr2023Batch_CASProj.Models.SecurityModel.User user = new IBMApr2023Batch_CASProj.Models.SecurityModel.User
            {
                UserName = existingPatient.User.UserName,
                UserPassword = existingPatient.User.UserPassword,
                UserRole = existingPatient.User.UserRole,
                LoginStatus = existingPatient.User.LoginStatus
            };



            patient.User = user;
            existingPatient.PatientFirstName = patient.PatientFirstName;
            existingPatient.PatientLastName = patient.PatientLastName;
            existingPatient.PatientPhone = patient.PatientPhone;
            existingPatient.PatientBloodGroup = patient.PatientBloodGroup;
            existingPatient.PatientDescription = patient.PatientDescription;
            existingPatient.PatientEmail = patient.PatientEmail;
            

            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");





        }

        public ActionResult DeletePatient(int? id)
        {
            var user = _db.Patients.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = _db.Patients.Find(id);

            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);

        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("DeletePatient")]
        public ActionResult DeletePConfirmed(int id)
        {
            Patient patient = _db.Patients.Find(id);
            _db.Patients.Remove(patient);
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

        public ActionResult SupplierDetails(int? id)
        {
            var user = _db.Suppliers.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _db.Suppliers.Find(id);

            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);


        }
        public ActionResult EditSupplierViewList()
        {
            return View(_db.Suppliers.Include("User").ToList());
        }
        public ActionResult EditSupplier(int? id)
        {
            var user = _db.Suppliers.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _db.Suppliers.Find(id);

            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);



        }
        [HttpPost]
        public ActionResult EditSupplier(IBMApr2023Batch_CASProj.Models.SecurityModel.Supplier supplier)
        {
            var existingSupplier = _db.Suppliers.Find(supplier.SupplierId);
            IBMApr2023Batch_CASProj.Models.SecurityModel.User user = new IBMApr2023Batch_CASProj.Models.SecurityModel.User
            {
                UserName = existingSupplier.User.UserName,
                UserPassword = existingSupplier.User.UserPassword,
                UserRole = existingSupplier.User.UserRole,
                LoginStatus = existingSupplier.User.LoginStatus
            };



            supplier.User = user;
            existingSupplier.SupplierFirstName = supplier.SupplierFirstName;
            existingSupplier.SupplierLastName = supplier.SupplierLastName;
            existingSupplier.SupplierPhone = supplier.SupplierPhone;
            existingSupplier.SupplierEmail = supplier.SupplierEmail;
            existingSupplier.SupplierDescription = supplier.SupplierDescription;

            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");





        }

        public ActionResult DeleteSupplier(int? id)
        {
            var user = _db.Suppliers.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _db.Suppliers.Find(id);

            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);

        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("DeleteSupplier")]
        public ActionResult DeleteSConfirmed(int id)
        {
            Supplier supplier = _db.Suppliers.Find(id);
            _db.Suppliers.Remove(supplier);
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
        public ActionResult SalesmanDetails(int? id)
        {
            var user = _db.Salesmen.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = _db.Salesmen.Find(id);

            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);


        }
        public ActionResult EditSalesmanViewList()
        {
            return View(_db.Salesmen.Include("User").ToList());
        }
        public ActionResult EditSalesman(int? id)
        {
            var user = _db.Salesmen.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = _db.Salesmen.Find(id);

            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);



        }
        [HttpPost]
        public ActionResult EditSalesman(IBMApr2023Batch_CASProj.Models.SecurityModel.Salesman salesman)
        {
            var existingSalesman = _db.Salesmen.Find(salesman.SalesmanId);
            IBMApr2023Batch_CASProj.Models.SecurityModel.User user = new IBMApr2023Batch_CASProj.Models.SecurityModel.User
            {
                UserName = existingSalesman.User.UserName,
                UserPassword = existingSalesman.User.UserPassword,
                UserRole = existingSalesman.User.UserRole,
                LoginStatus = existingSalesman.User.LoginStatus
            };



            salesman.User = user;
            existingSalesman.SalesmanFirstName = salesman.SalesmanFirstName;
            existingSalesman.SalesmanLastName = salesman.SalesmanLastName;
            existingSalesman.SalesmanPhone = salesman.SalesmanPhone;
            existingSalesman.SalesmanEmail = salesman.SalesmanEmail;
            existingSalesman.SalesmanDescription = salesman.SalesmanDescription;

            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");





        }

        public ActionResult DeleteSalesman(int? id)
        {
            var user = _db.Salesmen.FirstOrDefault(u => u.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = _db.Salesmen.Find(id);

            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);

        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("DeleteSalesman")]
        public ActionResult DeleteSaConfirmed(int id)
        {
            Salesman salesman = _db.Salesmen.Find(id);
            _db.Salesmen.Remove(salesman);
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

    }
}
