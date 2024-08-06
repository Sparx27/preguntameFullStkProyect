namespace preguntameWebAPI.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public string Username { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string? Apellido { get; set; }

        public string Correo { get; set; } = null!;

        public string? PaisId { get; set; }

        public string? FotoPath { get; set; }

        public decimal? Background { get; set; }
    }
}
