using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLabanowski.Models.Admin.Blog;
using CLabanowski.Models.Admin.Portfolio;
using CLabanowski.Models.Entities;
using CLabanowski.Models.Interfaces;

namespace CLabanowski.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IBlogPostRepository _blogRepo;
        private IPortfolioProjectRepository _portfolioRepo;

        public AdminController(IBlogPostRepository blogRepo,
            IPortfolioProjectRepository portfolioRepo)
        {
            _blogRepo = blogRepo;
            _portfolioRepo = portfolioRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Portfolio()
        {
            return View(GetAllProjectsForVm());
        }

        public AdminPortfolioVM GetAllProjectsForVm()
        {
            var projects = _portfolioRepo.GetAllPortfolioProjects();
            var model = new AdminPortfolioVM();

            //convert each portfolio project and add it to VM
            //in correct format
            foreach (var project in projects)
            {
                model.Projects.Add(new AdminPortfolioPartial
                {
                    Id = project.Id,
                    Title = project.Name
                });
            }

            model.Projects.OrderBy(m => m.Id);
            return model;
        }

        public ViewResult AddOrEditPortfolio(int? id)
        {
            //if no id given, send user to an empty form
            if (id == null)
            {
                return View(new AdminPortfolioFull());
            }

            var project = _portfolioRepo.GetPortfolioProject((int)id);

            //otherwise, if project exists, load its info into 
            //the form to be edited
            if (project != null)
            {
                var model = new AdminPortfolioFull
                {
                    Description = project.Description,
                    Id = project.Id,
                    ImgUrl = project.ImgUrl,
                    LinkUrl = project.LinkUrl,
                    Name = project.Name,
                    Technologies = project.Technologies
                };
                return View(model);
            }

            //if it does not exist, send back to main portfolio project page
            return View("Portfolio", GetAllProjectsForVm());
        }

        [HttpPost]
        public ActionResult AddOrEditPortfolio(AdminPortfolioFull model)
        {
            //if model state is valid, save the project to db
            if (ModelState.IsValid)
            {
                var project = new PortfolioProject
                {
                    Description = model.Description,
                    Id = model.Id,
                    ImgUrl = model.ImgUrl,
                    LinkUrl = model.LinkUrl,
                    Name = model.Name,
                    Technologies = model.Technologies
                };
                _portfolioRepo.SavePortfolioProject(project);
                return RedirectToAction("Portfolio");
            }

            //if model not valid, send user back to form with partial model
            return View(model);
        }

        [HttpPost]
        public ActionResult DeletePortfolioProject(int id)
        {
            _portfolioRepo.DeletePortfolioProject(id);
            return RedirectToAction("Portfolio", "Admin");
        }

        //gets all blog posts and converts them into correct 
        //format for view model
        public ViewResult Blog()
        {
            var posts = _blogRepo.GetAllBlogPosts();

            var model = new AdminBlogVM();
            foreach (var blogPost in posts)
            {
                model.BlogPosts.Add(new AdminBlogPartial
                {
                    Date = blogPost.Date.ToString("MMMM d, yyyy"),
                    Id = blogPost.Id,
                    Title = blogPost.Title
                });
            }
            return View(model);
        }

        public ViewResult AddOrEditBlogPost(int? id)
        {
            var model = new AdminBlogFull();

            //pass empty model to view for new post
            if (id == null)
            {
                model.Date = DateTime.Now.ToString("d");
                return View(model);
            }

            //otherwise, pass current blog data to be edited
            var post = _blogRepo.GetBlogPost((int)id);
            model.Date = post.Date.ToString("d");
            model.Id = post.Id;
            model.Text = post.Text;
            model.Title = post.Title;
            model.RouteName = post.RouteName;
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddOrEditBlogPost(AdminBlogFull model)
        {
            if (ModelState.IsValid)
            {
                //convert data format
                var post = new BlogPost
                {
                    Date = DateTime.Parse(model.Date),
                    Id = model.Id,
                    Text = model.Text,
                    Title = model.Title,
                    RouteName = model.RouteName
                };

                _blogRepo.SaveBlogPost(post);
                return RedirectToAction("Blog");
            }

            //if model not valid, send user back to form with model
            return View(model);
        }

        public ActionResult DeleteBlogPost(int id)
        {
            _blogRepo.DeleteBlogPost(id);
            return RedirectToAction("Blog", "Admin");
        }
    }
}