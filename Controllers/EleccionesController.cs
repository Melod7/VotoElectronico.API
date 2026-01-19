using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VotoElectronico.API.Data.Context;
using VotoElectronico.API.Models;

namespace VotoElectronico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN")]
    public class EleccionesController : ControllerBase
    {
        private readonly VotoElectronicoContext _context;
        

        public EleccionesController(VotoElectronicoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Crear(Eleccion eleccion)
        {
            _context.Elecciones.Add(eleccion);
            _context.SaveChanges();
            return Ok(eleccion);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.Elecciones.ToList());
        }
    }
}

