using Microsoft.EntityFrameworkCore;


namespace MusiikkiTehtava.Models
{
    public class MusiikkiContext : DbContext
    {
        public MusiikkiContext(DbContextOptions<MusiikkiContext> options) : base(options)
        {

        }
        public DbSet<Artisti> Artistit { get; set; }
        public DbSet<Kappale> Kappaleet { get; set; }
        public DbSet<Albumi> Albumit { get; set; }

        //Maaritellaan yhteys kappaleen ja albumin välille, sekä kappaleen ja artistin välille
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kappale>()
                .HasOne(p => p.Albumi)
                .WithMany(b => b.Kappalelistaus)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Kappale>()
                .HasOne(p => p.Artisti)
                .WithMany(b => b.Kappaleet)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
