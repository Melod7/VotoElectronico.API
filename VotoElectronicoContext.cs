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
    }
}

