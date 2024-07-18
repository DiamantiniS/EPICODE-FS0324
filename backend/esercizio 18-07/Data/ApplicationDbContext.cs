using Microsoft.EntityFrameworkCore;
using esercizio_18_07.Models;

namespace esercizio_18_07.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentUpdate> ShipmentUpdates { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShipmentUpdate>()
                .HasKey(su => su.UpdateId);

            modelBuilder.Entity<ShipmentUpdate>()
                .HasOne(su => su.Shipment)
                .WithMany(s => s.ShipmentUpdates)
                .HasForeignKey(su => su.ShipmentId);

            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Client)
                .WithMany(c => c.Shipments)  // Assicurati che questa linea sia corretta
                .HasForeignKey(s => s.ClientId);
        }
    }
}
