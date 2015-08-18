using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLabanowski;
using CLabanowski.Models.Context;
using CLabanowski.Models.Entities;
using CLabanowski.Models.Interfaces;

namespace CLabanowski.Models.Repositories
{
    public class EFPortfolioProjectRepository : IPortfolioProjectRepository
    {
        private CLabanowskiContext context = new CLabanowskiContext();

        public IQueryable<PortfolioProject> GetAllPortfolioProjects()
        {
            return context.PortfolioProjects;
        }

        public PortfolioProject GetPortfolioProject(int id)
        {
            return context.PortfolioProjects.Where(x => x.Id == id).FirstOrDefault();
        }

        public PortfolioProject SavePortfolioProject(PortfolioProject project)
        {
            var oldProject = context.PortfolioProjects.Find(project.Id);
            if (oldProject != null)
            {
                oldProject.Name = project.Name;
                oldProject.Description = project.Description;
                oldProject.Technologies = project.Technologies;
                oldProject.ImgUrl = project.ImgUrl;
            }
            else
            {
                context.PortfolioProjects.Add(project);
            }
            context.SaveChanges();
            return oldProject;   
            
        }

        public void DeletePortfolioProject(int id)
        {
            var project = context.PortfolioProjects.Find(id);
            if (project != null)
            {
                context.PortfolioProjects.Remove(project);
                context.SaveChanges();
            }
        }
    }
}
