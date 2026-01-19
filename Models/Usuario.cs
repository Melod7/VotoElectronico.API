using System.ComponentModel.DataAnnotations;

namespace VotoElectronico.API.Models;


    public class Usuario
    {
    public int Id { get; set; }

    public string Cedula { get; set; } = null!;
    public string Nombre{ get; set; } = null!;
    public string? Correo { get; set; }
    public string? Telefono { get; set; }

    public string? CodigoVerificacion { get; set; }
    public DateTime? CodigoExpira { get; set; }

    public bool YaVoto { get; set; }
    public bool Habilitado { get; set; }

    public int RolId { get; set; }
    public Rol Rol { get; set; } = null!;
}




