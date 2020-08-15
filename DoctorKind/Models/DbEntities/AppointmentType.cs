using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorKind.Models.DbEntities
{
    public class AppointmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class Appointment
    {
        public long Id { get; set; }
        [ForeignKey("Specialization")]
        public long SpecializationId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Doctor")]
        public long DoctorId { get; set; }
        [ForeignKey("TypeOfAppointment")]
        public int AppointmentType { get; set; }
        
        public string Timing { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual AppointmentType TypeOfAppointment { get; set; }
    }
}