using VotoElectronico.API.Models.Entities;

namespace VotoElectronico.API.Models
{
    public class Eleccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = "ABIERTA";

        public ICollection<Voto> Votos { get; set; } = new List<Voto>();
    }
}
