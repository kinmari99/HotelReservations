using Microsoft.EntityFrameworkCore;

namespace Hotel.Models
{
    public class HotelsDBContext : DbContext
    {
        public HotelsDBContext(DbContextOptions<HotelsDBContext> options) : base(options)
        { }
        public DbSet<Newsletter> Newsletters { get; set; }

        public DbSet<Rezerwacja> Reservations { get; set; }

        public DbSet<Użytkownik> Users { get; set; }

        public DbSet<Pracownik> Workers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezerwacja>()
            .HasKey(u => u.Id);  
            modelBuilder.Entity<Rezerwacja>()
                .Property(u => u.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Rezerwacja>()
           .HasOne(r => r.użytkownik)  
           .WithMany(u => u.Reservations)  
           .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Newsletter>()
        .HasOne(r => r.użytkownik)
        .WithMany(u => u.Newsletters)
        .HasForeignKey(r => r.UserId);

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Pracownik>().HasData(
            new Pracownik { Id = 1, Name = "Anna", Surname="Kowalska", Email="akowalska@hotelxyz.pl" },
            new Pracownik { Id = 2, Name = "Jan", Surname="Iksiński", Email = "jiksinski@hotelxyz.pl" },
            new Pracownik { Id = 3, Name = "Piotr", Surname="Nowak", Email = "pnowak@hotelxyz.pl" }
            );
            modelBuilder.Entity<Użytkownik>().HasData(
          new Użytkownik { Id = 1, Name = "Katarzyna", Surname = "Kowalska", Email = "kkowalska@gmail.com", IsAdmin=true, Nickname="123456789", Haslo="zaq1@WSX", powtorzHaslo="zaq1@WSX" }

          );

        }
    }
}