using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class BlogContext : DbContext
    {
        public DbSet<Blogger> Bloggers { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public string conn = "data source=.;initial catalog=blog;integrated security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            //=> options.UseSqlite("Data Source=blogging.db");
            => options.UseSqlServer(conn);
    }

    [Table("Blogger")]
    public class Blogger
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<BlogPost> Posts { get; } = new List<BlogPost>();
    }

    [Table("BlogPost")]
    public class BlogPost
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blogger Blog { get; set; }
    }
}