using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLabanowski.Validation;
using DataAnnotationsExtensions;

namespace CLabanowski.Models.Admin.Portfolio
{
    public class AdminPortfolioFull
    {
        [Required(ErrorMessage = "You must enter a value")]
        [Integer(ErrorMessage = "You must enter a number")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter the name of the project")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must enter at least one technology")]
        [DataType(DataType.MultilineText)]
        public string Technologies { get; set; }

        [Required(ErrorMessage = "You must enter a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You must enter a link")]
        [BeginsWithHttp]
        public string LinkUrl { get; set; }

        [Required(ErrorMessage = "You must enter an image location")]
        [BeginsWithCorrectPath]
        [IsJpegOrPng]
        public string ImgUrl { get; set; }
    }
}