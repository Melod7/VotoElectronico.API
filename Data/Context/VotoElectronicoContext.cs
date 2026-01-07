using Microsoft.EntityFrameworkCore;
using VotoElectronico.API.Models;

namespace VotoElectronico.API.Data.Context
{
    public class VotoElectronicoContext : DbContext
    {
        public VotoElectronicoContext(DbContextOptions<VotoElectronicoContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Eleccion> Elecciones { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Voto> Votos { get; set; }
    }
}
