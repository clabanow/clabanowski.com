using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CLabanowski.Validation;
using DataAnnotationsExtensions;

namespace CLabanowski.Models.Admin.Blog
{
    public class AdminBlogFull
    {
        //[Required(ErrorMessage = "You must enter a value")]
        //[Integer(ErrorMessage = "You must enter a number")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a blog post name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must enter a blog post")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [Required(ErrorMessage = "You must enter a date")]
        [ReasonableDate]
        public string Date { get; set; }

        [Required(ErrorMessage = "You must enter a route name")]
        [RegularExpression("^(?! )[0-9a-zA-Z-]*$", ErrorMessage = "You may only enter letters, numbers, and dashes")]
        public string RouteName { get; set; }
    }
}