namespace VotoElectronico.API.DTOs
{
    public class VotoPorCodigoDTO
    {
        public string Cedula { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public int EleccionId { get; set; }
        public int CandidatoId { get; set; }
    }
}

