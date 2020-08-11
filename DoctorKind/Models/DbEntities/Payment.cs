using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorKind.Models.DbEntities
{
    public class Payment
    {
        public long Id { get; set; }
        public string TransactionId { get; set; }
        public string PaymentId { get; set; }
    }
}