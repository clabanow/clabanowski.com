using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLabanowski.Validation
{
    public class ReasonableDateAttribute : ValidationAttribute
    {
        public ReasonableDateAttribute()
        {
            ErrorMessage = "The date must be between Jan 1 2014 and today";
        }

        public override bool IsValid(object value)
        {
            var start = new DateTime(2014, 1, 1);
            var end = DateTime.Now;

            return DateTime.Parse((string)value) >= start && DateTime.Parse((string)value) <= end;
        }
    }
}