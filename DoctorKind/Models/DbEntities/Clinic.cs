using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorKind.Models.DbEntities
{
    public class Clinic
    {
        public long Id{get;set;}
        [ForeignKey("Doctors")]
        public long DoctorId { get; set; }
        public string ClinicName{get;set;}
        public string Address{get;set;}
        public string ClinicImages{ get;set;}
        public string Timings { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}