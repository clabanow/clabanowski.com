using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLabanowski.Models.Admin.Portfolio
{
    public class AdminPortfolioVM
    {
        public List<AdminPortfolioPartial> Projects { get; set; }

        public AdminPortfolioVM()
        {
            Projects = new List<AdminPortfolioPartial>();
        }
    }
}