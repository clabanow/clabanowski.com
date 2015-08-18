using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CLabanowski.Models.Admin.Blog;
using CLabanowski.Models.Admin.Portfolio;
using CLabanowski.Models.Entities;
using CLabanowski.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CLabanowski;
using CLabanowski.Controllers;
using Moq;

namespace CLabanowski.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        private Mock<IBlogPostRepository> blogMock = new Mock<IBlogPostRepository>();
        private Mock<IPortfolioProjectRepository> portfolioMock = new Mock<IPortfolioProjectRepository>();

        [TestMethod]
        public void AdminBlogContainsAllPosts()
        {
            var target = GetAdminController();
            var result = (AdminBlogVM) target.Blog().ViewData.Model;
            Assert.AreEqual(result.BlogPosts[0].Title, "Sample");
        }

        [TestMethod]
        public void CanEditBlog()
        {
            var mockedBlogRepo = new Mock<IBlogPostRepository>();
            var mockedProjectRepo = new Mock<IPortfolioProjectRepository>();
            var blogPost = new BlogPost
            {
                Id = 1,
                Date = new DateTime(2012, 1, 1),
                RouteName = "sample-post",
                Text = "This is a sample",
                Title = "Sample Post"
            };
            mockedBlogRepo.Setup(m => m.GetBlogPost(1)).Returns(blogPost);

            var target = new AdminController(mockedBlogRepo.Object, mockedProjectRepo.Object);

            var result = (AdminBlogFull)target.AddOrEditBlogPost(1).ViewData.Model;
            Assert.AreEqual(result.Title, "Sample Post");
        }

        [TestMethod]
        public void CannotEditNonexistentBlogPost()
        {
            var target = GetAdminController();
            var result = (AdminBlogFull) target.AddOrEditBlogPost(33).ViewData.Model;
            Assert.AreEqual(result.Date, DateTime.Now.ToString("d"));
        }

        [TestMethod]
        public void CanSaveValidBlogChanges()
        {
            //insert test here
        }

        [TestMethod]
        public void CanDeleteBlogPost()
        {
            var postToDelete = new BlogPost
            {
                Id = 1,
                Date = new DateTime(2014, 1, 1),
                RouteName = "blog-post",
                Text = "this is a sample",
                Title = "Sample"
            };

            var target = GetAdminController();
            var result = target.DeleteBlogPost(postToDelete.Id);
            blogMock.Verify(m => m.DeleteBlogPost(postToDelete.Id));
        }

        [TestMethod]
        public void CannotSaveInvalidBlogChanges()
        {
            var target = GetAdminController();
            target.ModelState.AddModelError("error", "error");

            var post = new AdminBlogFull
            {
                Id = 3,
                Title = "A New Project",
                Date = DateTime.Now.ToString("d"),
                RouteName = "sample-post",
                Text = "this is a sample post"
            };

            var result = target.AddOrEditBlogPost(post);
            blogMock.Verify(m => m.SaveBlogPost(It.IsAny<BlogPost>()), Times.Never);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void AdminPortfolioContainsAllProjects()
        {
            var target = GetAdminController();

            var result = ((AdminPortfolioVM)target.Portfolio().ViewData.Model);

            Assert.AreEqual(result.Projects[0].Title, "FutureCodr");
            Assert.AreEqual(result.Projects.Count(), 2);
        }

        [TestMethod]
        public void CanEditPortfolio()
        {
            var mockedBlogRepo = new Mock<IBlogPostRepository>();
            var mockedPortfolioRepo = new Mock<IPortfolioProjectRepository>();

            mockedPortfolioRepo.Setup(m => m.GetPortfolioProject(1)).Returns(new PortfolioProject
            {
                Id = 1,
                Name = "FutureCodr",
                Description = "sample desc",
                Technologies = "ASP.NET, Javascript",
                ImgUrl = "/Content",
                LinkUrl = "futurecodr.com"
            });

            var target = new AdminController(mockedBlogRepo.Object, mockedPortfolioRepo.Object);

            var result = (AdminPortfolioFull)target.AddOrEditPortfolio(1).ViewData.Model;
            Assert.AreEqual(result.Name, "FutureCodr");
        }

        [TestMethod]
        public void CannotEditNonexistentPortfolio()
        {
            var target = GetAdminController();
            var result = (AdminPortfolioVM)target.AddOrEditPortfolio(55).ViewData.Model;
            Assert.AreEqual(result.Projects.Count(), 2);
        }

        [TestMethod]
        public void CanSaveValidPortfolioChanges()
        {
            var mockedBlog = new Mock<IBlogPostRepository>();
            var mockedPortfolio = new Mock<IPortfolioProjectRepository>();
            var target = new AdminController(mockedBlog.Object, mockedPortfolio.Object);

            var project = new AdminPortfolioFull
            {
                Id = 3,
                Name = "A New Project",
                Description = "desc",
                ImgUrl = "/Content",
                LinkUrl = "www.sample.com",
                Technologies = "C#, Java"
            };

            var sameProject = new PortfolioProject
            {
                Id = 3,
                Name = "A New Project",
                Description = "desc",
                ImgUrl = "/Content",
                LinkUrl = "www.sample.com",
                Technologies = "C#, Java"
            };
            
            //mockedPortfolio.Setup(m => m.SavePortfolioProject(sameProject)).Returns(sameProject);
            
            var result = target.AddOrEditPortfolio(project);

            portfolioMock.Verify(m => m.SavePortfolioProject(sameProject));

            Assert.IsInstanceOfType(result, typeof (RedirectResult));
        }

        [TestMethod]
        public void CannotSaveInvalidPortfolioChanges()
        {
            var target = GetAdminController();
            target.ModelState.AddModelError("error", "error");

            var project = new AdminPortfolioFull
            {
                Id = 3,
                Name = "A New Project",
                Description = "desc",
                ImgUrl = "/Content",
                LinkUrl = "www.sample.com",
                Technologies = "C#, Java"
            };

            var result = target.AddOrEditPortfolio(project);
            portfolioMock.Verify(m => m.SavePortfolioProject(It.IsAny<PortfolioProject>()), Times.Never);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CanDeletePortfolioProject()
        {
            var projectToDelete = new PortfolioProject
            {
                Id = 1,
                Name = "FutureCodr",
                Description = "sample desc",
                Technologies = "ASP.NET, Javascript",
                ImgUrl = "/Content",
                LinkUrl = "futurecodr.com"
            };

            var target = GetAdminController();
            var result = target.DeletePortfolioProject(projectToDelete.Id);
            portfolioMock.Verify(m => m.DeletePortfolioProject(projectToDelete.Id));
        }

        private AdminController GetAdminController()
        {
            return new AdminController(GetBlogMock(), GetPortfolioMock());
        }

        private IBlogPostRepository GetBlogMock()
        {
            blogMock.Setup(m => m.GetAllBlogPosts()).Returns(new BlogPost[]
            {
                new BlogPost
                {
                    Id = 1, 
                    Date = new DateTime(2014, 1, 1), 
                    RouteName = "blog-post", 
                    Text = "this is a sample", 
                    Title = "Sample"
                }
            }.AsQueryable());

            return blogMock.Object;
        }

        private IPortfolioProjectRepository GetPortfolioMock()
        {
            portfolioMock.Setup(m => m.GetAllPortfolioProjects()).Returns(new PortfolioProject[]
            {
                new PortfolioProject
                {
                    Id = 1,
                    Name = "FutureCodr",
                    Description = "sample desc",
                    Technologies = "ASP.NET, Javascript",
                    ImgUrl = "/Content",
                    LinkUrl = "futurecodr.com"
                },
                new PortfolioProject
                {
                    Id = 2,
                    Name = "Personal blog",
                    Description = "sample desc",
                    Technologies = "ASP.NET, Javascript",
                    ImgUrl = "/Content",
                    LinkUrl = "clabanowski.com"
                }
            }.AsQueryable());

            return portfolioMock.Object;
        }
    }
}
