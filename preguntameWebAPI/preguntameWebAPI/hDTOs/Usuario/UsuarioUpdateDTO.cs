using System.ComponentModel.DataAnnotations;

namespace preguntameWebAPI.DTOs.Usuario
{
    public class UsuarioUpdateDTO
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Nombre { get; set; } = null!;

        public string? Apellido { get; set; }
        public string? PaisId { get; set; }
        public string? FotoPath { get; set; }
        public decimal? Background { get; set; }
    }
}
