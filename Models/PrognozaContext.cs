using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class PrognozaContext : DbContext
    {
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Mesec> Meseci { get; set; }

        public PrognozaContext(DbContextOptions options) : base(options)
        {

        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Predmet>()
                        .HasMany<Spoj>(p => p.PredmetStudent)
                        .WithOne(p => p.Predmet);
        }*/
    }
}
