using Microsoft.AspNetCore.Mvc;
using VotoElectronico.API.Data.Context;
using VotoElectronico.API.DTOs.Auth;
using VotoElectronico.API.Models;
using VotoElectronico.API.Utils;

namespace VotoElectronico.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly VotoElectronicoContext _context;

    public AuthController(VotoElectronicoContext context)
    {
        _context = context;
    }

    // JUEZ DE MESA
    [HttpPost("habilitar-voto")]
    public IActionResult HabilitarVoto(SolicitarCodigoDTO dto)
    {
        var usuario = _context.Usuarios
            .FirstOrDefault(u => u.Cedula == dto.Cedula && u.Habilitado);

        if (usuario == null)
            return NotFound("La persona no está en el padrón electoral");

        if (usuario.YaVoto)
            return BadRequest("El votante ya ejerció su derecho al voto");

        // Código alfanumérico de 6
        var codigo = CodigoHelper.GenerarCodigo();

        usuario.CodigoVerificacion = codigo;
        usuario.CodigoExpira = DateTime.Now.AddMinutes(10);

        _context.SaveChanges();

        // Simulación de envío
        Console.WriteLine($" Email a {usuario.Correo}: Código {codigo}");
        Console.WriteLine($" SMS a {usuario.Telefono}: Código {codigo}");

        return Ok("Votante habilitado. Código enviado.");
    }
}
