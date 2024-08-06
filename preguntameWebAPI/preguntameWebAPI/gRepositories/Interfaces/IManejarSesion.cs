using preguntameWebAPI.DTOs.Usuario;

namespace preguntameWebAPI.Repositories.Interfaces
{
    public interface IManejarSesion
    {
        Task<UsuarioInsertDTO> Registro();
        Task<UsuarioDTO> LogIn(string usuario, string password);
        Task LogOut();
    }
}
