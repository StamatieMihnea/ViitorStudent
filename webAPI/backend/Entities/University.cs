﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace backend.Entities
{
    public partial class University
    {
        public University()
        {
            Meeting = new HashSet<Meeting>();
            Reviews = new HashSet<Reviews>();
            UniversityClub = new HashSet<UniversityClub>();
            UniversityInterest = new HashSet<UniversityInterest>();
            UniversityJob = new HashSet<UniversityJob>();
            UniversitySubject = new HashSet<UniversitySubject>();
        }

        public int university_id { get; set; }
        public string name { get; set; }
        public string group { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string examInfo { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public int city_id { get; set; }

        public virtual City city { get; set; }
        public virtual ICollection<Meeting> Meeting { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<UniversityClub> UniversityClub { get; set; }
        public virtual ICollection<UniversityInterest> UniversityInterest { get; set; }
        public virtual ICollection<UniversityJob> UniversityJob { get; set; }
        public virtual ICollection<UniversitySubject> UniversitySubject { get; set; }
    }
}