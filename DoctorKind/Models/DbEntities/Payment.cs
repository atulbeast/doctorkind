using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorKind.Models.DbEntities
{
    public class Payment
    {
        public long Id { get; set; }
        public string TransactionId { get; set; }
        public string PaymentId { get; set; }
        [ForeignKey("Appointment")]
        public long AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}