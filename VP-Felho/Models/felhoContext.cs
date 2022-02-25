using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VP_Felho.Models
{
    public partial class felhoContext : DbContext
    {
        public felhoContext()
        {
        }

        public felhoContext(DbContextOptions<felhoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fajl> Fajlok { get; set; }
        public virtual DbSet<Felhasznalo> Felhasznalok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["FelhoDB"].ConnectionString;
                optionsBuilder.UseMySql(connectionString, ServerVersion.Parse("10.4.21-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Fajl>(entity =>
            {
                entity.Property(e => e.datum).HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.felhasznalo)
                    .WithMany(p => p.fajl)
                    .HasForeignKey(d => d.felhasznalo_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fajl_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
