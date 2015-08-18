using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLabanowski.Models.Admin.Blog
{
    public class AdminBlogVM
    {
        public List<AdminBlogPartial> BlogPosts { get; set; }

        public AdminBlogVM()
        {
            BlogPosts = new List<AdminBlogPartial>();
        }
    }
}