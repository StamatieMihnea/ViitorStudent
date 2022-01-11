﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace backend.Entities
{
    public partial class Meeting
    {
        public Meeting()
        {
            UserMetings = new HashSet<UserMetings>();
        }

        public int meeting_id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public string link { get; set; }
        public int university_id { get; set; }

        public virtual University university { get; set; }
        public virtual ICollection<UserMetings> UserMetings { get; set; }
    }
}