using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VotoElectronico.API.Data.Context;
using VotoElectronico.API.DTOs;
using VotoElectronico.API.Models;

namespace VotoElectronico.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VotosController : ControllerBase

{
    private readonly VotoElectronicoContext _context;

    public VotosController(VotoElectronicoContext context)
    {
        _context = context;
    }
    [HttpPost("validar-cedula")]
    public async Task<IActionResult> ValidarCedula([FromBody] ValidarCedulaDTO dto)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Cedula == dto.Cedula);

        if (usuario == null)
            return NotFound("Cédula no registrada");

        return Ok("Cédula válida");
    }

    [HttpPost("votar-por-codigo")]
    public IActionResult VotarPorCodigo(VotoPorCodigoDTO dto)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u =>
            u.Cedula == dto.Cedula &&
            u.CodigoVerificacion == dto.Codigo &&
            u.CodigoExpira > DateTime.Now &&
            !u.YaVoto
        );

        if (usuario == null)
            return Unauthorized("Código inválido, expirado o votante no habilitado");

        var eleccion = _context.Elecciones.FirstOrDefault(e =>
            e.Id == dto.EleccionId && e.Activa);

        if (eleccion == null)
            return BadRequest("La elección no está activa");

        var voto = new Voto
        {
            UsuarioId = usuario.Id,
            EleccionId = dto.EleccionId,
            CandidatoId = dto.CandidatoId,
            Fecha = DateTime.Now
        };

        usuario.YaVoto = true;
        usuario.CodigoVerificacion = null;
        usuario.CodigoExpira = null;

        _context.Votos.Add(voto);
        _context.SaveChanges();

        // Confirmación de sufragio
        Console.WriteLine($" Email a {usuario.Correo}: Su voto fue registrado");
        Console.WriteLine($"  SMS a {usuario.Telefono}: Gracias por votar");

        return Ok("Voto registrado correctamente");
    }
}
