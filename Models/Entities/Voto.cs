namespace VotoElectronico.API.Models
{
    public class Voto
    {
        public int Id { get; set; }

        public int EleccionId { get; set; }
        public Eleccion Eleccion { get; set; }

        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        public int UsuarioId { get; set; } // Solo para validación (NO se expone)
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
