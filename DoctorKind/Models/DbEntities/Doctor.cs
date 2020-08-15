using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorKind.Models.DbEntities
{
    public class Doctor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Qualification { get; set; }
        public string Description { get; set; }
        public string EmailId { get; set; }
        public string RegistrationNo { get; set; }
        public string DoctorImage { get; set; }
        public string RelevantDocument { get; set; }
        public string SubscriptionStatus {get;set;}
        public string StartTime {get;set;}
        public string EndTime {get;set;}
        public string WorkingDays {get;set;}
        public string ApprovalStatus {get;set;}
        public long UserId { get; set; }
        public bool IsActive {get;set;}
        public virtual ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }
    }

    public class DoctorSpecialization
    {
        public long Id { get; set; }
        public decimal VideoConsulationFee { get; set; }
        public decimal AudioConsultationFee { get; set; }
        public decimal ChatConsultationFree { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Specialization")]
        public long SpecializationId { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        [ForeignKey("Doctor")]
        public long DoctorId { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
   
}