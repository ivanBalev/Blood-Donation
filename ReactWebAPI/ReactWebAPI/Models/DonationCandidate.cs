﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWebAPI.Models
{
    public class DonationCandidate
    {
        public DonationCandidate()
        {
            this.id = Guid.NewGuid().ToString();
        }

        [Key]
        public string id { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string fullName { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string mobile { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }

        public int age { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string bloodGroup { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string address { get; set; }
    }
}
