using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotoElectronico.API.Data.Context;
using VotoElectronico.API.DTOs;
using VotoElectronico.API.Models;

namespace VotoElectronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public AuthController(VotoElectronicoContext context)
        {
            _context = context;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null)
                return BadRequest("Datos de login inválidos");

            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u =>
                    u.Correo == loginDTO.Correo &&
                    u.Clave == loginDTO.Contraseña
                );

            if (usuario == null)
                return Unauthorized("Credenciales incorrectas");

            // Respuesta simple (sin exponer la clave)
            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Correo,
                Rol = usuario.Rol.Nombre
            });
        }
    }
}

