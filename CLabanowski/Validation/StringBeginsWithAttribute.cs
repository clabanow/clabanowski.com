using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CLabanowski.Validation
{
    public class BeginsWithHttpAttribute : ValidationAttribute
    {
        public BeginsWithHttpAttribute()
        {
            ErrorMessage = "The value must being with 'http'";
        }

        public override bool IsValid(object value)
        {
            return !string.IsNullOrEmpty((string)value) && value.ToString().Substring(0, 4).ToLower() == "http";
        }
    }

    public class BeginsWithCorrectPathAttribute : ValidationAttribute
    {
        public BeginsWithCorrectPathAttribute()
        {
            ErrorMessage = "The value must begin with '/Content/thumbnails/'";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            return value.ToString().Length >= 20 &&
                   value.ToString().Substring(0, 20) == "/Content/thumbnails/";
        }
    }

    public class IsJpegOrPngAttribute : ValidationAttribute
    {
        public IsJpegOrPngAttribute()
        {
            ErrorMessage = "The file must be a JPEG or PNG file";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var length = value.ToString().Length;

            return length > 3 &&
                   (value.ToString().Substring(length - 4).ToLower() == ".png" ||
                    value.ToString().Substring(length - 4).ToLower() == ".jpg" ||
                    value.ToString().Substring(length - 5).ToLower() == ".jpeg");
        }
    }
}