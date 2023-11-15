using Microsoft.EntityFrameworkCore;

namespace api_pessoa.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<Pessoa>? pessoas { get; set; }

    }


}
