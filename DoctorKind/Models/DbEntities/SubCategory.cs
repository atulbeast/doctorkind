﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorKind.Models.DbEntities
{
    public class SubCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CategoryId { get;set; }
    }
}