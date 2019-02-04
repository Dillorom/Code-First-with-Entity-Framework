using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogging
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new BloggingContext())
            //{
            //    // Create and save a new Blog
            //    Console.Write("Enter a name for a new Blog: ");
            //    var name = Console.ReadLine();

            //    Console.WriteLine("Enter the URL: ");
            //    string url = Console.ReadLine();

            //    var blog = new Blog { Name = name, Url = url };
            //    db.Blogs.Add(blog);
            //    db.SaveChanges();

            //    // Display all Blogs from the database
            //    List<Blog> query = db.Blogs.OrderBy(d => d.Name).ToList();

            //    Console.WriteLine("All blogs in the database:");
            //    foreach (var item in query)
            //    {
            //        Console.WriteLine($"{item.Name} - {item.Url}");
            //    }

            //    Console.WriteLine("Press any key to exit...");
            //    Console.ReadKey();
            //}

            using (var db = new BloggingContext())
            {
                Console.WriteLine("Enter the post title: ");
                string title = Console.ReadLine();

                Console.WriteLine("Enter the post content: ");
                string content = Console.ReadLine();

                Console.WriteLine("Enter the blog id: ");
                int blogId = int.Parse(Console.ReadLine());

                var post = new Post { Title = title, Content = content, BlogId = blogId };
                db.Posts.Add(post);
                db.SaveChanges();

                var query = from p in db.Posts
                            orderby p.Title
                            select p;

                Console.WriteLine("All blogs in the database:");
                foreach (var p in db.Posts)
                {
                    Console.WriteLine($"{p.BlogId}. {p.Title} - {p.Content}");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

        }
    }
}
