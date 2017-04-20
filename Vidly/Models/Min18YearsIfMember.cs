using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.PayAsYouGo || customer.MembershipTypeId == MembershipType.unknown)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birth date is required.");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success :
                new ValidationResult("Customer should be at least 18 years old to go on a membership");
        }
    }
}