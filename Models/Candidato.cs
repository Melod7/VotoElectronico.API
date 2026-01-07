using VotoElectronico.API.Models;

namespace VotoElectronico.API.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int EleccionId { get; set; }
        public Eleccion Eleccion { get; set; }

        public ICollection<Voto> Votos { get; set; }
    }
}
