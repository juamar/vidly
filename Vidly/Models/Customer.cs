﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Usted es tonto")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display (Name = "Membership type")]
        public byte MembershipTypeId { get; set; }

        [Display (Name = "Date of birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}