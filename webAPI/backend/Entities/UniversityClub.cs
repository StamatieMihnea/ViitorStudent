﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Entities
{
    public partial class UniversityClub
    {
        public int universityClub_id { get; set; }
        public int club_id { get; set; }
        public int university_id { get; set; }

        public virtual Club club { get; set; }
        public virtual University university { get; set; }
    }
}