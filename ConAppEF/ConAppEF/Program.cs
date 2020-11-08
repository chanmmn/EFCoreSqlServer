using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            using (var db = new BloggingContext())
            {
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog {BlogId=1, Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                //blog.Url = "https://devblogs.microsoft.com/dotnet";
                //blog.Posts.Add(
                //    new Post
                //    {
                //        PostId = 1,
                //        Title = "Hello World",
                //        Content = "I wrote an app using EF Core!",
                //        BlogId = 1
                //    }); ;
                db.Add(new Post
                {
                    PostId = 1,
                    Title = "Hello World",
                    Content = "I wrote an app using EF Core!",
                    BlogId = 1
                }
                    );
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}