using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class StockGratterThan0 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Movies movie = (Movies)validationContext.ObjectInstance;

            return (movie.NumberInStock > 0) ? ValidationResult.Success :
                new ValidationResult("Number in stock should be at least 1 item.");
        }
    }
}