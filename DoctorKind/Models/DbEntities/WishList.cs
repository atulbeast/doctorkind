using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorKind.Models.DbEntities
{
    public class WishList
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int SubCategoryId { get; set; }
    }
}