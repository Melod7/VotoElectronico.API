using Microsoft.EntityFrameworkCore;
using VotoElectronico.API.Data.Context;
using VotoElectronico.API.Models;


namespace VotoElectronico.API.Data.Seed
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<VotoElectronicoContext>();

            context.Database.Migrate();

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Rol { Nombre = "ADMIN" },
                    new Rol { Nombre = "VOTANTE" }
                );
                context.SaveChanges();
            }

            if (!context.Usuarios.Any())
            {
                context.Usuarios.Add(new Usuario
                {
                    Nombre = "Administrador",
                    Correo = "admin@voto.com",
                    Clave = "admin123",
                    RolId = context.Roles.First(r => r.Nombre == "ADMIN").Id
                });
                context.SaveChanges();
            }
        }
    }
}