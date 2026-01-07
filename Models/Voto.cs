using VotoElectronico.API.Models;

namespace VotoElectronico.API.Models
{
    public class Voto
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int EleccionId { get; set; }
        public Eleccion Eleccion { get; set; }

        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        public DateTime Fecha { get; set; }
    }
}
