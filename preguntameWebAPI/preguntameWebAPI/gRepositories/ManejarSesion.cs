using preguntameWebAPI.DTOs.Usuario;
using preguntameWebAPI.Repositories.Interfaces;

namespace preguntameWebAPI.Repositories
{
    public class ManejarSesion : IManejarSesion
    {
        public Task<UsuarioDTO> LogIn(string usuario, string password)
        {
            throw new NotImplementedException();
        }

        public Task LogOut()
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioInsertDTO> Registro()
        {
            throw new NotImplementedException();
        }
    }
}
