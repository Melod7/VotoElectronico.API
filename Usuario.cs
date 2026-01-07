using System.ComponentModel.DataAnnotations;

namespace VotoElectronico.API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string Password_Hash { get; set; }
        public DateTime Creado_En { get; set; }
    }
}
