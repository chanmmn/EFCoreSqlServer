using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace EFGetStarted
{
    public class BlogContext : DbContext
    {
        static IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        public static IConfigurationRoot configuration = builder.Build();

        public DbSet<Blogger> Bloggers { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        //public string conn = "data source=.;initial catalog=blog;integrated security=True";
        public string conn = configuration.GetConnectionString("DBConnection");
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