using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using esercizio_18_07.Models;
using Microsoft.AspNetCore.Identity;

namespace esercizio_18_07.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentUpdate> ShipmentUpdates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurazione della chiave primaria per ShipmentUpdate
            modelBuilder.Entity<ShipmentUpdate>()
                .HasKey(su => su.UpdateId);

            // Configurazione delle relazioni
            modelBuilder.Entity<ShipmentUpdate>()
                .HasOne(su => su.Shipment)
                .WithMany(s => s.ShipmentUpdates)
                .HasForeignKey(su => su.ShipmentId);
        }
    }
}
