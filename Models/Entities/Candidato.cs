namespace VotoElectronico.API.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int EleccionId { get; set; }
        public Eleccion Eleccion { get; set; }
    }
}
