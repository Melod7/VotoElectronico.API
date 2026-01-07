using VotoElectronico.API.Models;

namespace VotoElectronico.API.Models
{
    public class Eleccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activa { get; set; }

        public ICollection<Voto> Votos { get; set; }
    }
}
