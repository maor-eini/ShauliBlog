using ShauliBlog.Models;
using System.Data.Entity;

namespace ShauliBlog.Data
{

    class ShauliBlogDbContext : DbContext
    {
        public DbSet<Fan> Fans { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}