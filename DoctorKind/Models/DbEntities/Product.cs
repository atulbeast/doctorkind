using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorKind.Models.DbEntities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int stock { get; set; }
        public float Price { get; set; }
        public float DiscountPrice { get; set; }
        public long SubCategoryId { get; set; }
    }
}