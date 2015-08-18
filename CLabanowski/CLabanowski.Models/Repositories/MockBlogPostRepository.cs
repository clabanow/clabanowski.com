using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CLabanowski.Models.Entities;
using CLabanowski.Models.Interfaces;

namespace CLabanowski.Models.Repositories
{
    public class MockBlogPostRepository : IBlogPostRepository
    {
        private List<BlogPost> blogPosts = new List<BlogPost> 
        {
            new BlogPost
            {
                Date = new DateTime(2013, 1, 15),
                Id = 1,
                Title = "Sample Post #1",
                RouteName = "first-sample-post",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pretium eros vitae lorem ultrices, non ullamcorper est fringilla. Sed massa tortor, iaculis ut commodo volutpat, laoreet et diam. Nulla elementum tellus in sapien porta euismod. Maecenas in pulvinar dolor, nec luctus sem. Integer non leo ac tellus aliquet imperdiet vel vel erat. Aliquam et odio a nunc sollicitudin adipiscing. Ut varius aliquet felis, quis ultrices mauris aliquet sit amet. Proin ultricies suscipit nisi ut blandit. Phasellus eget purus sollicitudin, pharetra tellus non, pretium est. Nulla et congue augue, eu egestas urna. Morbi mollis dui vitae metus luctus aliquam. Aliquam a sem scelerisque, volutpat arcu in, varius mi. Sed et sagittis ipsum, nec lobortis mi. Sed fermentum et mauris eu ultrices. Vestibulum vulputate placerat tortor. Donec lobortis tincidunt mi, sed viverra nulla scelerisque vitae."
            },
            new BlogPost
            {
                Date = new DateTime(2013, 2, 15),
                Id = 2,
                Title = "Sample Post #2",
                RouteName = "second-sample-post",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pretium eros vitae lorem ultrices, non ullamcorper est fringilla. Sed massa tortor, iaculis ut commodo volutpat, laoreet et diam. Nulla elementum tellus in sapien porta euismod. Maecenas in pulvinar dolor, nec luctus sem. Integer non leo ac tellus aliquet imperdiet vel vel erat. Aliquam et odio a nunc sollicitudin adipiscing. Ut varius aliquet felis, quis ultrices mauris aliquet sit amet. Proin ultricies suscipit nisi ut blandit. Phasellus eget purus sollicitudin, pharetra tellus non, pretium est. Nulla et congue augue, eu egestas urna. Morbi mollis dui vitae metus luctus aliquam. Aliquam a sem scelerisque, volutpat arcu in, varius mi. Sed et sagittis ipsum, nec lobortis mi. Sed fermentum et mauris eu ultrices. Vestibulum vulputate placerat tortor. Donec lobortis tincidunt mi, sed viverra nulla scelerisque vitae."
            },
            new BlogPost
            {
                Date = new DateTime(2013, 3, 15),
                Id = 3,
                Title = "Sample Post #3",
                RouteName = "third-sample-post",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pretium eros vitae lorem ultrices, non ullamcorper est fringilla. Sed massa tortor, iaculis ut commodo volutpat, laoreet et diam. Nulla elementum tellus in sapien porta euismod. Maecenas in pulvinar dolor, nec luctus sem. Integer non leo ac tellus aliquet imperdiet vel vel erat. Aliquam et odio a nunc sollicitudin adipiscing. Ut varius aliquet felis, quis ultrices mauris aliquet sit amet. Proin ultricies suscipit nisi ut blandit. Phasellus eget purus sollicitudin, pharetra tellus non, pretium est. Nulla et congue augue, eu egestas urna. Morbi mollis dui vitae metus luctus aliquam. Aliquam a sem scelerisque, volutpat arcu in, varius mi. Sed et sagittis ipsum, nec lobortis mi. Sed fermentum et mauris eu ultrices. Vestibulum vulputate placerat tortor. Donec lobortis tincidunt mi, sed viverra nulla scelerisque vitae."
            },
            new BlogPost
            {
                Date = new DateTime(2013, 4, 15),
                Id = 4,
                Title = "Sample Post #4",
                RouteName = "fourth-sample-post",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pretium eros vitae lorem ultrices, non ullamcorper est fringilla. Sed massa tortor, iaculis ut commodo volutpat, laoreet et diam. Nulla elementum tellus in sapien porta euismod. Maecenas in pulvinar dolor, nec luctus sem. Integer non leo ac tellus aliquet imperdiet vel vel erat. Aliquam et odio a nunc sollicitudin adipiscing. Ut varius aliquet felis, quis ultrices mauris aliquet sit amet. Proin ultricies suscipit nisi ut blandit. Phasellus eget purus sollicitudin, pharetra tellus non, pretium est. Nulla et congue augue, eu egestas urna. Morbi mollis dui vitae metus luctus aliquam. Aliquam a sem scelerisque, volutpat arcu in, varius mi. Sed et sagittis ipsum, nec lobortis mi. Sed fermentum et mauris eu ultrices. Vestibulum vulputate placerat tortor. Donec lobortis tincidunt mi, sed viverra nulla scelerisque vitae."
            },
            new BlogPost
            {
                Date = new DateTime(2013, 4, 16),
                Id = 5,
                Title = "Sample Post #5",
                RouteName = "fifth-sample-post",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pretium eros vitae lorem ultrices, non ullamcorper est fringilla. Sed massa tortor, iaculis ut commodo volutpat, laoreet et diam. Nulla elementum tellus in sapien porta euismod. Maecenas in pulvinar dolor, nec luctus sem. Integer non leo ac tellus aliquet imperdiet vel vel erat. Aliquam et odio a nunc sollicitudin adipiscing. Ut varius aliquet felis, quis ultrices mauris aliquet sit amet. Proin ultricies suscipit nisi ut blandit. Phasellus eget purus sollicitudin, pharetra tellus non, pretium est. Nulla et congue augue, eu egestas urna. Morbi mollis dui vitae metus luctus aliquam. Aliquam a sem scelerisque, volutpat arcu in, varius mi. Sed et sagittis ipsum, nec lobortis mi. Sed fermentum et mauris eu ultrices. Vestibulum vulputate placerat tortor. Donec lobortis tincidunt mi, sed viverra nulla scelerisque vitae."
            },
            new BlogPost
            {
                Date = new DateTime(2013, 4, 17),
                Id = 6,
                Title = "Sample Post #6",
                RouteName = "sixth-sample-post",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pretium eros vitae lorem ultrices, non ullamcorper est fringilla. Sed massa tortor, iaculis ut commodo volutpat, laoreet et diam. Nulla elementum tellus in sapien porta euismod. Maecenas in pulvinar dolor, nec luctus sem. Integer non leo ac tellus aliquet imperdiet vel vel erat. Aliquam et odio a nunc sollicitudin adipiscing. Ut varius aliquet felis, quis ultrices mauris aliquet sit amet. Proin ultricies suscipit nisi ut blandit. Phasellus eget purus sollicitudin, pharetra tellus non, pretium est. Nulla et congue augue, eu egestas urna. Morbi mollis dui vitae metus luctus aliquam. Aliquam a sem scelerisque, volutpat arcu in, varius mi. Sed et sagittis ipsum, nec lobortis mi. Sed fermentum et mauris eu ultrices. Vestibulum vulputate placerat tortor. Donec lobortis tincidunt mi, sed viverra nulla scelerisque vitae."
            }
        };

        public IQueryable<Entities.BlogPost> GetAllBlogPosts()
        {
            return blogPosts.AsQueryable();
        }

        public Entities.BlogPost GetBlogPost(int id)
        {
            return blogPosts.Where(m => m.Id == id).FirstOrDefault();
        }

        public Entities.BlogPost SaveBlogPost(Entities.BlogPost post)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlogPost(int id)
        {
            throw new NotImplementedException();
        }


        public BlogPost GetBlogPostByRouteName(string routeName)
        {
            return blogPosts.Where(m => m.RouteName == routeName).FirstOrDefault();
        }
    }
}
