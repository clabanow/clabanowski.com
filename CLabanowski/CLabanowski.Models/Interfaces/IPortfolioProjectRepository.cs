using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLabanowski.Models.Entities;

namespace CLabanowski.Models.Interfaces
{
    public interface IPortfolioProjectRepository
    {
        IQueryable<PortfolioProject> GetAllPortfolioProjects();
        PortfolioProject GetPortfolioProject(int id);
        PortfolioProject SavePortfolioProject(PortfolioProject project);
        void DeletePortfolioProject(int id);
    }
}
