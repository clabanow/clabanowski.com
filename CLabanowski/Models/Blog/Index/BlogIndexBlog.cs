using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLabanowski.Models.Blog.Index
{
    public class BlogIndexBlog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TrimmedText { get; set; }
        public string Date { get; set; }
        public string RouteName { get; set; }
    }
}