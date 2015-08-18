using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLabanowski.Models.Blog.Index
{
    public class BlogIndexVM
    {
        public List<BlogIndexBlog> Blogs { get; set; }
        public int Page { get; set; }
        public bool HasOlderPages { get; set; }
        public bool HasNewerPages { get; set; }

        public BlogIndexVM()
        {
            Blogs = new List<BlogIndexBlog>();
        }
    }
}