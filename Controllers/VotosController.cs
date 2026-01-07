using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VotoElectronico.API.Data.Context;
using VotoElectronico.API.Models;

namespace VotoElectronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "VOTANTE")]
    public class VotosController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public VotosController(VotoElectronicoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Votar(int eleccionId, int candidatoId)
        {
            int usuarioId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            bool yaVoto = _context.Votos.Any(v =>
                v.EleccionId == eleccionId && v.UsuarioId == usuarioId);

            if (yaVoto)
                return BadRequest("El usuario ya votó en esta elección.");

            var voto = new Voto
            {
                EleccionId = eleccionId,
                CandidatoId = candidatoId,
                UsuarioId = usuarioId
            };

            _context.Votos.Add(voto);
            _context.SaveChanges();

            return Ok("Voto registrado correctamente.");
        }
    }
}
