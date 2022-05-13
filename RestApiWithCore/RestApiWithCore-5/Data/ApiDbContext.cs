using Microsoft.EntityFrameworkCore;
using RestApiWithCore_5.Models;

namespace RestApiWithCore_5.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) :base(options)
        {

        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Song>().HasData();
        }*/
    }
}
