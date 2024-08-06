using preguntameWebAPI.DTOs.Usuario;
using preguntameWebAPI.DTOs.UsuarioPregunta;

namespace preguntameWebAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> GetUsuario(string username);
        Task<UsuarioDTO> EditarUsuario(UsuarioUpdateDTO usuarioUpdateDTO);
        Task<IEnumerable<UsPrDTO>> GetPreguntas(string username);
        Task<IEnumerable<UsPrDTO>> GetRespuestas(string username);
        Task ResponderPregunta(UsPrUpdateDTO usPrUpdateDTO);
        Task HacerPregunta();
        Task DarLike();
    }
}
