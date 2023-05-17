using IBM_CAS.Models.SecuritydbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using IBM_CAS.Models;

namespace IBM_CAS.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        Models.SecuritydbModel.ClinicAutomationSystemIBMEntities _db = new Models.SecuritydbModel.ClinicAutomationSystemIBMEntities();
        

        // GET: Patient
        public ActionResult Index()
        {

            //var patient = _db.Patients.FirstOrDefault();

            //return RedirectToAction("PatientDetails", new { id = patient.PatientId });
            var username = User.Identity.Name;

            var patient = _db.Patients.FirstOrDefault(u => u.User.UserName == username);

            if (patient == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("PatientDetails", new { id = patient.PatientId });


        }
        public ActionResult PatientDetails(int? id)
        {
            var user = _db.Patients.FirstOrDefault(u => u.PatientId == id);
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
        public ActionResult EditPatient(Models.SecuritydbModel.Patient patient)
        {
            var existingPatient = _db.Patients.Find(patient.PatientId);
            Models.SecuritydbModel.User user = new Models.SecuritydbModel.User
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
            return RedirectToAction("Index", "Patient");





        }

    }
}