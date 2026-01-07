using Microsoft.AspNetCore.Mvc;
using VotoElectronico.API.Data.Context;

namespace VotoElectronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultadosController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public ResultadosController(VotoElectronicoContext context)
        {
            _context = context;
        }

        [HttpGet("{eleccionId}")]
        public IActionResult Resultados(int eleccionId)
        {
            var resultados = _context.Votos
                .Where(v => v.EleccionId == eleccionId)
                .GroupBy(v => v.CandidatoId)
                .Select(g => new
                {
                    CandidatoId = g.Key,
                    TotalVotos = g.Count()
                });

            return Ok(resultados);
        }
    }
}
