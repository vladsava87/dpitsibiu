using System;
using System.Linq;
using DatabaseLayer;
using DatabaseLayer.DataModels;


namespace EntityFrameworkText
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CatalogContex())
            {
                // Create and save a new Blog 
                //Console.Write("Select operation: ");
                //var op = Console.ReadLine();

                var profesori = db.Profesorii.ToList();

                foreach (var profesor in profesori)
                {
                    Console.WriteLine("====BEGIN DATE PROFESOR====");
                    Console.WriteLine(profesor.Nume);
                    Console.WriteLine(profesor.Prenume);
                    Console.WriteLine(profesor.Email);
                    Console.WriteLine(profesor.Telefon);

                    Console.WriteLine("++++ MATERII PROFESOR ++++");
                    foreach (var materie in profesor.Materie)
                    {
                        Console.WriteLine("-----> Materie");
                        Console.WriteLine(materie.Materie.Nume);
                        Console.WriteLine(materie.Materie.Optional);
                        Console.WriteLine("-----> END Materie");
                    }
                    Console.WriteLine("++++ END MATERII PROFESOR ++++");

                    Console.WriteLine("====END DATE PROFESOR====");
                }

                //switch (op)
                //{
                //    // Insert new Post
                //    case "ip":

                //        Console.Write("Enter Title for a new Post: ");
                //        var postname = Console.ReadLine();
                //        Console.Write("Enter Content for a new Post: ");
                //        var content = Console.ReadLine();
                //        Console.Write("Enter Blog ID of new Post: ");
                //        var bId = Convert.ToInt32(Console.ReadLine());

                //        var post = new Post {
                //            Title = postname,
                //            Content = content,
                //            BlogId = bId
                //        };
                //        db.Posts.Add(post);
                //        db.SaveChanges();
                //        Console.WriteLine();

                //        break;

                //    // Insert new Blog
                //    case "ib":
                //        Console.Write("Enter a name for a new Blog: ");
                //        var blogname = Console.ReadLine();

                //        var blog = new Blog { Name = blogname };
                //        db.Blogs.Add(blog);
                //        db.SaveChanges();
                //        Console.WriteLine();

                //        break;

                //    // Cancel
                //    case "c":
                //        Console.WriteLine("Cancelled...");
                //        Console.WriteLine();

                //        break;

                //    // List Post Item
                //    case "lp":

                //        Console.Write("Select Post by id: ");
                //        var pId = Convert.ToInt32(Console.ReadLine());

                //        var postsQuery = (from p in db.Posts where p.PostId == pId 
                //                         select p).FirstOrDefault() ;

                //        if(postsQuery != null)
                //        {
                //            Console.WriteLine(string.Format("PID: {0}", postsQuery.PostId));
                //            Console.WriteLine(string.Format("Title: {0}", postsQuery.Title));
                //            Console.WriteLine(string.Format("Content: {0}", postsQuery.Content));
                //            Console.WriteLine(string.Format("Blog: {0}", postsQuery.Blog.Name));
                //        }
                //        Console.WriteLine();

                //        break;

                //    // List Blog Item
                //    case "lb":

                //        Console.Write("Select Blog by id: ");
                //        var lBId = Convert.ToInt32(Console.ReadLine());

                //        var blogsQuery = (from p in db.Blogs
                //                          where p.BlogId == lBId
                //                          select p).FirstOrDefault();

                //        if (blogsQuery != null)
                //        {
                //            Console.WriteLine(string.Format("BID: {0}", blogsQuery.BlogId));
                //            Console.WriteLine(string.Format("Name: {0}", blogsQuery.Name));
                //            Console.WriteLine(string.Format("Url: {0}", blogsQuery.Url));
                //        }
                //        Console.WriteLine();

                //        break;

                //    // Delete Post Item
                //    case "dp":

                //        Console.Write("Delete Post by id: ");
                //        var pdId = Convert.ToInt32(Console.ReadLine());

                //        var dpostsQuery = (from p in db.Posts
                //                          where p.PostId == pdId
                //                           select p).FirstOrDefault();

                //        db.Posts.Remove(dpostsQuery);
                //        db.SaveChanges();

                //        Console.WriteLine("Post removed... ");
                //        Console.WriteLine("");

                //        break;

                //    // Delete Blog Item
                //    case "db":

                //        Console.Write("Delete Blog by id: ");
                //        var bdId = Convert.ToInt32(Console.ReadLine());

                //        var dblogsQuery = (from p in db.Blogs
                //                           where p.BlogId == bdId
                //                           select p).FirstOrDefault();

                //        try
                //        {
                //            db.Blogs.Remove(dblogsQuery);
                //            db.SaveChanges();

                //        }
                //        finally
                //        {
                //            Console.WriteLine("Blog removed... ");
                //            Console.WriteLine("");
                //        }
                //        break;

                //    // Update/change a Post Item
                //    case "up":
                //        Console.Write("Update Post by id: ");
                //        var udId = Convert.ToInt32(Console.ReadLine());

                //        var upostsQuery = (from p in db.Posts
                //                           where p.PostId == udId
                //                           select p).FirstOrDefault();

                        
                //        Console.Write("Enter a new Title for this Post: ");
                //        var ntitle = Console.ReadLine();
                //        Console.Write("Enter new Content for this Post: ");
                //        var ncontent = Console.ReadLine();
                //        Console.Write("Enter new Blog ID for this Post: ");
                //        var nbId = Convert.ToInt32(Console.ReadLine());

                //        if(upostsQuery != null)
                //        {
                //            upostsQuery.Content = ncontent;
                //            upostsQuery.Title = ntitle;
                //            upostsQuery.BlogId = nbId;

                //            db.SaveChanges();
                //        }

                //        Console.WriteLine("Post Updated... ");
                //        Console.WriteLine("");

                //        break;

                //    // Update/change a Blog Item
                //    case "ub":
                //        Console.Write("Update Blog by id: ");
                //        var ubId = Convert.ToInt32(Console.ReadLine());

                //        var ublogsQuery = (from p in db.Blogs
                //                           where p.BlogId == ubId
                //                           select p).FirstOrDefault();


                //        Console.Write("Enter a new Name for this Blog: ");
                //        var nname = Console.ReadLine();
                //        Console.Write("Enter new URL for this Blog: ");
                //        var nurl = Console.ReadLine();

                //        if (ublogsQuery != null)
                //        {
                //            ublogsQuery.Name = nname;
                //            ublogsQuery.Url = nurl;

                //            db.SaveChanges();
                //        }

                //        Console.WriteLine("Blog Updated... ");
                //        //Console.WriteLine("");

                //        break;

                //    // default -> no matching operation found - no matching conditions found
                //    default:
                //        break;
                //}

                //// Display all Blogs from the database 
                //var blogquery = from b in db.Blogs
                //            orderby b.Name
                //            select b;

                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in blogquery)
                //{
                //    var postsQuery = from p in db.Posts
                //                     where p.BlogId == item.BlogId
                //                     select p;

                //    Console.WriteLine(string.Format("{0} ({1})", item.Name, postsQuery.Count()));
                //}

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
