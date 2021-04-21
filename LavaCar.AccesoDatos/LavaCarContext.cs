using LavaCar.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LavaCar.AccesoDatos
{
    public partial class LavaCarContext : DbContext
    {
        public LavaCarContext(DbContextOptions<LavaCarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }
        public virtual DbSet<VehiculoServicio> VehiculoServicios { get; set; }

        //Creado por defecto en el Scaffold
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.Property(e => e.Dueno).IsUnicode(false);

                entity.Property(e => e.Marca).IsUnicode(false);

                entity.Property(e => e.Placa).IsUnicode(false);
            });

            modelBuilder.Entity<VehiculoServicio>(entity =>
            {
                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.VehiculoServicios)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicio");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.VehiculoServicios)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
