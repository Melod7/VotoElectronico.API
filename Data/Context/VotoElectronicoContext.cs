using Microsoft.EntityFrameworkCore;
using VotoElectronico.API.Models;

namespace VotoElectronico.API.Data.Context
{

    public class VotoElectronicoContext : DbContext
    {
        public VotoElectronicoContext(DbContextOptions<VotoElectronicoContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Eleccion> Elecciones { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Voto> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Rol
            modelBuilder.Entity<Rol>()
                .Property(r => r.Nombre)
                .IsRequired();

            // Usuario
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Cedula)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.RolId);

            // Voto (anonimato)
            modelBuilder.Entity<Voto>()
                .HasOne(v => v.Eleccion)
                .WithMany()
                .HasForeignKey(v => v.EleccionId);

            modelBuilder.Entity<Voto>()
                .HasOne(v => v.Candidato)
                .WithMany()
                .HasForeignKey(v => v.CandidatoId);
        }
    }
}