using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorKind.Models.DbEntities
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url{get;set;}
        [ForeignKey("Doctor")]
        public long DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}