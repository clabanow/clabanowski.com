using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CLabanowski.Models.Entities;

namespace CLabanowski.Models.Portfolio.Index
{
    public class PortfolioIndexVM
    {
        public List<PortfolioProject> Projects { get; set; }

        public PortfolioIndexVM()
        {
            Projects = new List<PortfolioProject>();
        }
    }
}