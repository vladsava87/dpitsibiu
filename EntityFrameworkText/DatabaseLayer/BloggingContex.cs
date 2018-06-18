using System.Data.Entity;
using DatabaseLayer.DataModels;

namespace DatabaseLayer
{
    public class BloggingContex : DbContext
    {
        public BloggingContex(string connectionName)
            : base(string.Format("name={0}", connectionName))
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
