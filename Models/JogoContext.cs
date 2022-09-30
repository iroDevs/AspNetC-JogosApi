using Microsoft.EntityFrameworkCore;

namespace Jogos_API.Models
{
    public class JogoContext : DbContext
    {

        public JogoContext(DbContextOptions<JogoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Jogo> Jogos { get; set; }
    }
}
