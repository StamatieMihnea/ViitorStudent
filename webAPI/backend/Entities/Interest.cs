﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace backend.Entities
{
    public partial class Interest
    {
        public Interest()
        {
            UniversityInterest = new HashSet<UniversityInterest>();
            UserInterest = new HashSet<UserInterest>();
        }

        public int interest_id { get; set; }
        public string name { get; set; }

        public virtual ICollection<UniversityInterest> UniversityInterest { get; set; }
        public virtual ICollection<UserInterest> UserInterest { get; set; }
    }
}