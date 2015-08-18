using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLabanowski.Models.Entities;
using CLabanowski.Models.Interfaces;

namespace CLabanowski.Models.Repositories
{
    public class MockPortfolioProjectRepository : IPortfolioProjectRepository
    {
        private List<PortfolioProject> projects = new List<PortfolioProject>
        {
            new PortfolioProject
            {
                Id = 1,
                Name = "FutureCodr",
                Technologies = "ASP.NET, Javascript, HTML, CSS",
                Description = "FutureCodr is a website to help prospective programming bootcamp students find and compare courses that was written on the ASP.NET MVC platform. Microsoft SQL Server was used as the database, and on the backend admin side, AngularJS was used extensively.",
                LinkUrl = "http://www.futurecodr.com",
                ImgUrl = "/Content/thumbnails/Futurecodr_tn.png"
            },
            new PortfolioProject
            {
                Id = 3,
                Name = "AngularJS To Do List",
                Technologies = "ASP.NET, Javascript, HTML, CSS",
                Description = "FutureCodr is a website to help prospective programming bootcamp students find and compare courses that was written on the ASP.NET MVC platform. Microsoft SQL Server was used as the database, and on the backend admin side, AngularJS was used extensively.",
                LinkUrl = "http://www.futurecodr.com",
                ImgUrl = "/Content/thumbnails/Clabanowski_tn.png"
            },
            new PortfolioProject
            {
                Id = 2,
                Name = "CLabanowski.com",
                Technologies = "ASP.NET, Javascript, HTML, CSS",
                Description = "FutureCodr is a website to help prospective programming bootcamp students find and compare courses that was written on the ASP.NET MVC platform. Microsoft SQL Server was used as the database, and on the backend admin side, AngularJS was used extensively.",
                LinkUrl = "http://www.futurecodr.com",
                ImgUrl = "/Content/thumbnails/Clabanowski_tn.png"
            }
        }; 

        public IQueryable<Entities.PortfolioProject> GetAllPortfolioProjects()
        {
            return projects.AsQueryable();
        }

        public Entities.PortfolioProject GetPortfolioProject(int id)
        {
            return projects.Where(m => m.Id == id).FirstOrDefault();
        }

        public Entities.PortfolioProject SavePortfolioProject(Entities.PortfolioProject project)
        {
            throw new NotImplementedException();
        }

        public void DeletePortfolioProject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
