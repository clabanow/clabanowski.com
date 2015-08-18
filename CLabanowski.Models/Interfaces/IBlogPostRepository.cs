using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLabanowski.Models.Entities;

namespace CLabanowski.Models.Interfaces
{
    public interface IBlogPostRepository
    {
        IQueryable<BlogPost> GetAllBlogPosts();
        BlogPost GetBlogPost(int id);
        BlogPost SaveBlogPost(BlogPost post);
        BlogPost GetBlogPostByRouteName(string routeName);
        void DeleteBlogPost(int id);
    }
}
