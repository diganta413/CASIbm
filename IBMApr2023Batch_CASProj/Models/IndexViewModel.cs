using IBM_CAS.Models.SecuritydbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBM_CAS.Models
{
    public class IndexViewModel
    {
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Salesman> Salesmen { get; set;}
        public int DoctorCount => Doctors.Count;
        public int PatientCount => Patients.Count;
        public int SupplierCount => Suppliers.Count;
        public int SalesmanCount => Salesmen.Count;
    }
}