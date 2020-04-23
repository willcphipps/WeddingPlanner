using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WeddingPlanner.Models {
    public class FutureDateAttribute : ValidationAttribute {
        protected override ValidationResult IsValid (object value, ValidationContext validationContext) {
            if (value is DateTime) {
                DateTime compare = (DateTime) value;
                if (compare > DateTime.Now) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult ("Date must be in future");
                }
            } else {
                return new ValidationResult ("This is not a valid date");
            }
        }

    }
}