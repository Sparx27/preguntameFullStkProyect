using preguntameWebAPI.DTOs.Usuario;
using preguntameWebAPI.DTOs.UsuarioPregunta;
using preguntameWebAPI.Models;

namespace preguntameWebAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuario(string username);
        void EditarUsuario(Usuario usuario);
        Task<UsuarioPregunta> GetPregunta(int preguntaId, string username);
        Task<List<UsuarioPregunta>> GetPreguntas(string username);
        Task<List<UsuarioPregunta>> GetRespuestas(string username);
        void ResponderPregunta(UsuarioPregunta usuarioPregunta);
        Task HacerPregunta();
        Task DarLike();
        Task GuardarCambios();
    }
}
