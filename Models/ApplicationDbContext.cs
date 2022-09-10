using Microsoft.EntityFrameworkCore;

namespace Docker.Les.Admin.API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Colour> Colours { get; set; }
    }
}
