namespace preguntameWebAPI.DTOs.Usuario
{
    public class UsuarioInsertDTO
    {
        public string Username { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }
        public string Correo { get; set; } = null!;
        public string UsuarioPassword { get; set; } = null!;
        public string PaisId { get; set; } = null!;
    }
}
