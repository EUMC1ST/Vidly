using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public enum MembershipTypes : int
    {
        PayAsYouGo = 1,
        Monthly = 2,
        Quarterly = 3,
        AnnalGo = 2
   
    }
    public class Min18YearsIfAMember : ValidationAttribute
    {
        /*
            Validates the specified value "Birthdate{get; set;}" with
            respect to the current validation attribute [Min18YearsIfAMember].             
        */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //this give us access to the containing class 
            var customer = (Customer)validationContext.ObjectInstance;
            

            if (customer.MembershipTypeId == (int)MembershipTypes.PayAsYouGo || customer.MembershipTypeId == 0)
            {
                 return ValidationResult.Success;
            }
            if (customer.BirthDay == null)
            {
                return new ValidationResult("BirthDay is required");
            }

            var age = DateTime.Today.Year - customer.BirthDay.Value.Year;
            
            return age>=18 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a MemberShip");
        }   
    }
}