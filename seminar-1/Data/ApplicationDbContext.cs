using Microsoft.EntityFrameworkCore;
using seminar_1.Data.Model;

namespace seminar_1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {

        }

        public DbSet<Students> Students { get; set; }
    }
}
