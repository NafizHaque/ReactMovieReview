using Microsoft.EntityFrameworkCore;
using MovieReviewCore.Models;

namespace MovieReviewCore.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<User> User { get; set; }
    }
}
