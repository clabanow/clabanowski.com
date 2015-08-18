using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLabanowski.Models.Context;
using CLabanowski.Models.Entities;
using CLabanowski.Models.Interfaces;

namespace CLabanowski.Models.Repositories
{
    public class EFBlogPostRepository : IBlogPostRepository
    {
        private CLabanowskiContext context = new CLabanowskiContext();

        public IQueryable<BlogPost> GetAllBlogPosts()
        {
            return context.BlogPosts;
        }

        public BlogPost GetBlogPost(int id)
        {
            return context.BlogPosts.Where(x => x.Id == id).FirstOrDefault();
        }

        public BlogPost SaveBlogPost(BlogPost post)
        {
            //add a post...
            if (post.Id == 0)
            {
                //first assign the post a new id
                if (!context.BlogPosts.Any())
                {
                    post.Id = 1;
                }
                else
                {
                    post.Id = context.BlogPosts.Max(x => x.Id) + 1;
                }
                //then add it to the db and save changes
                context.BlogPosts.Add(post);
                context.SaveChanges();
                return post;
            }

            //otherwise post already exists and should be edited
            else
            {
                var oldPost = context.BlogPosts.Find(post.Id);
                if (oldPost != null)
                {
                    oldPost.Title = post.Title;
                    oldPost.Text = post.Text;
                    oldPost.Date = post.Date;
                    context.SaveChanges();
                }
                return oldPost;
            }
        }

        public void DeleteBlogPost(int id)
        {
            var post = context.BlogPosts.Find(id);
            if (post != null)
            {
                context.BlogPosts.Remove(post);
                context.SaveChanges();
            }
        }
        
        public BlogPost GetBlogPostByRouteName(string routeName)
        {
            return context.BlogPosts.Where(m => m.RouteName == routeName).FirstOrDefault();
        }
    }
}
