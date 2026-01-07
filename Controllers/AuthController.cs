using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VotoElectronico.API.Data.Context;
using VotoElectronico.API.DTOs;


namespace VotoElectronico.API.Controllers
    {
        [ApiController]
        [Route("api/auth")]
        public class AuthController : ControllerBase
        {
            private readonly VotoElectronicoContext _context;
            private readonly IConfiguration _config;

            public AuthController(VotoElectronicoContext context, IConfiguration config)
            {
                _context = context;
                _config = config;
            }

            [HttpPost("login")]
            public IActionResult Login(LoginDTO dto)
            {
                var usuario = _context.Usuarios
                    .FirstOrDefault(u => u.Cedula == dto.Cedula && u.Password_Hash == dto.Password);

                if (usuario == null)
                    return Unauthorized();

                var claims = new[]
                {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config["Jwt:Key"])
                );

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
        }
    }
