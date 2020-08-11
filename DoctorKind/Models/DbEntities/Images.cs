using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorKind.Models.DbEntities
{
    public class Images
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public int ItemType { get; set; }
        public long ItemId { get; set; }
    }
}