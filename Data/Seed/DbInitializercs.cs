using Microsoft.EntityFrameworkCore;
using VotoElectronico.API.Data.Context;
using VotoElectronico.API.Models;


namespace VotoElectronico.API.Data
{
        public static class DbInitializercs
        {
            public static void Seed(VotoElectronicoContext context)
            {
                // Roles
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Rol { Nombre = "ADMIN" },
                        new Rol { Nombre = "VOTANTE" }
                    );
                    context.SaveChanges();
                }

                // Usuario votante de prueba
                if (!context.Usuarios.Any())
                {
                    var rolVotante = context.Roles.First(r => r.Nombre == "VOTANTE");

                    context.Usuarios.Add(new Usuario
                    {
                        Cedula = "0102030405",
                        Nombre = "Votante Prueba",
                        Correo = "votante@test.com",
                        Telefono = "0999999999",
                        YaVoto = false,
                        RolId = rolVotante.Id
                    });

                    context.SaveChanges();
                }
            }
        }
    }




