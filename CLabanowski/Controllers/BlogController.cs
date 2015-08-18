using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLabanowski.Models.Blog.Blog;
using CLabanowski.Models.Blog.Index;
using CLabanowski.Models.Interfaces;

namespace CLabanowski.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        //sets the amount of blog post stubs per page in blog 
        //overview page
        public int pageSize = 4;
        private IBlogPostRepository _blogRepo;

        public BlogController(IBlogPostRepository blogRepo)
        {
            _blogRepo = blogRepo;
        }

        public ActionResult Index(int page = 1)
        {
            var blogs = _blogRepo.GetAllBlogPosts();

            //get the 5 blog posts for the relevant page
            var blogsToShow = blogs
                .OrderByDescending(x => x.Date)
                .Skip((page - 1)*pageSize)
                .Take(pageSize);

            //create view model and pass in meta page info
            var model = new BlogIndexVM
            {
                Page = page,
                HasOlderPages = blogs.Count() > page * pageSize,
                HasNewerPages = page > 1
            };

            //add blog previews to model with trimmed text
            foreach (var blogPost in blogsToShow)
            {
                model.Blogs.Add(new BlogIndexBlog
                {
                    Date = blogPost.Date.ToString("MMMM d, yyyy"),
                    Id = blogPost.Id,
                    Title = blogPost.Title,
                    RouteName = blogPost.RouteName,
                    TrimmedText = blogPost.Text.Length <= 180 
                        ? blogPost.Text 
                        : blogPost.Text.Substring(0, 180) + " ..."
                });
            }

            return View(model);
        }

        public ActionResult Blog(string id)
        {
            var blogPost = _blogRepo.GetBlogPostByRouteName(id);

            var model = new BlogBlogVM
            {
                Id = blogPost.Id,
                Date = blogPost.Date.ToString("MMMM d, yyyy"),
                Text = blogPost.Text,
                Title = blogPost.Title
            };

            return View(model);
        }
    }
}