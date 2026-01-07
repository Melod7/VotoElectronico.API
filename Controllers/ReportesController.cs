using Microsoft.AspNetCore.Mvc;
using System.Text;
using VotoElectronico.API.Data.Context;

namespace VotoElectronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;

        public ReportesController(VotoElectronicoContext context)
        {
            _context = context;
        }

        [HttpGet("csv/{eleccionId}")]
        public IActionResult ExportarCSV(int eleccionId)
        {
            var resultados = _context.Votos
                .Where(v => v.EleccionId == eleccionId)
                .GroupBy(v => v.Candidato.Nombre)
                .Select(g => new { Candidato = g.Key, Total = g.Count() })
                .ToList();

            var csv = new StringBuilder();
            csv.AppendLine("Candidato,Votos");

            foreach (var r in resultados)
                csv.AppendLine($"{r.Candidato},{r.Total}");

            return File(
                Encoding.UTF8.GetBytes(csv.ToString()),
                "text/csv",
                "resultados_eleccion.csv"
            );
        }
    }
}
