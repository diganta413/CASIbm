//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IBMApr2023Batch_CASProj.Models.SecurityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorDescription { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorSpec { get; set; }
        public string DoctorPhone { get; set; }
        public string DoctorStatus { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
