﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace backend.Entities
{
    public partial class UniversityJob
    {
        public int universityJob_id { get; set; }
        public int job_id { get; set; }
        public int university_id { get; set; }

        public virtual Job job { get; set; }
        public virtual University university { get; set; }
    }
}