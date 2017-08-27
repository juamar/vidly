using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Driving licence")]
        public string DrivingLicence { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
    }
}