using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLabanowski.Models.Interfaces;
using CLabanowski.Models.Portfolio.Index;

namespace CLabanowski.Controllers
{
    [AllowAnonymous]
    public class PortfolioController : Controller
    {
        private IPortfolioProjectRepository _portfolioRepo;

        public PortfolioController(IPortfolioProjectRepository portfolioRepo)
        {
            _portfolioRepo = portfolioRepo;
        }
        public ActionResult Index()
        {
            var projects = _portfolioRepo.GetAllPortfolioProjects();

            var model = new PortfolioIndexVM
            {
                Projects = projects.ToList()
            };

            return View(model);
        }
    }
}