using preguntameWebAPI.DTOs.Usuario;
using preguntameWebAPI.DTOs.UsuarioPregunta;
using preguntameWebAPI.hDTOs;
using preguntameWebAPI.Repositories.Interfaces;
using preguntameWebAPI.Services.Interfaces;

namespace preguntameWebAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDTO> GetUsuario(string username)
        {
            var resDb = await _usuarioRepository.GetUsuario(username);
            return new UsuarioDTO
            {
                Username = resDb.Username,
                Nombre = resDb.Nombre,
                Apellido = resDb.Apellido,
                Correo = resDb.Correo,
                PaisId = resDb.PaisId,
                FotoPath = resDb.FotoPath,
                Background = resDb.Background
            };
        }

        public async Task<UsuarioDTO> EditarUsuario(UsuarioUpdateDTO usuarioUpdateDTO)
        {
            var resDb = await _usuarioRepository.GetUsuario(usuarioUpdateDTO.Username);
            if (resDb == null) return null;

            //Faltaria validar que el usuarioUpdateDTO.Username sea igual que el username del usuario logueado

            resDb.Nombre = usuarioUpdateDTO.Nombre;
            if(!string.IsNullOrEmpty(resDb.Apellido))
            {
                resDb.Apellido = usuarioUpdateDTO.Apellido;
            }
            if (!string.IsNullOrEmpty(resDb.PaisId))
            {
                resDb.PaisId = usuarioUpdateDTO.PaisId;
            }
            if(!string.IsNullOrEmpty(resDb.FotoPath))
            {
                resDb.FotoPath = usuarioUpdateDTO.FotoPath;
            }
            if(resDb.Background != 0)
            {
                resDb.Background = usuarioUpdateDTO.Background;
            }
            _usuarioRepository.EditarUsuario(resDb);

            await _usuarioRepository.GuardarCambios();
            return new UsuarioDTO
            {
                Username = resDb.Username,
                Nombre = resDb.Nombre,
                Apellido = resDb.Apellido,
                Correo = resDb.Correo,
                PaisId = resDb.PaisId,
                FotoPath = resDb.FotoPath,
                Background = resDb.Background
            };
        }

        public async Task<IEnumerable<UsPrDTO>> GetPreguntas(string username)
        {
            var resDbList = await _usuarioRepository.GetPreguntas(username);
            return resDbList.Select(up => new UsPrDTO
            {
                PreguntaId = up.PreguntaId,
                UsernameConsultado = up.UsernameConsultado,
                UsernameConsultante = up.UsernameConsultante ?? "Anónimo", //Si es null, lo transforma a Anónimo
                Fecha = up.Pregunta.Fecha,
                Dsc = up.Pregunta.Dsc
            });
        }

        public async Task ResponderPregunta(UsPrUpdateDTO usPrUpdateDTO)
        {
            //Falta validar que la pregunta enviada desde el frontend perteneza al usuarioLogueado
            var resPrDb = await _usuarioRepository.GetPregunta(usPrUpdateDTO.PreguntaId, usPrUpdateDTO.UsernameConsultado);

            if (resPrDb == null) throw new Exception("No se encontró la pregunta solicitada");
            if(
                string.IsNullOrEmpty(usPrUpdateDTO.DscRespuesta) || 
                usPrUpdateDTO.DscRespuesta.Length <= 2 || 
                usPrUpdateDTO.DscRespuesta.Length > 1000)
            {
                throw new Exception("La respuesta debe contener entre 2 caracteres y 1000 caracteres");
            }
            if (resPrDb.Estado == true) throw new Exception("La pregunta ya fue respondida");

            resPrDb.Estado = true;
            resPrDb.FechaRespuesta = DateTime.Now;
            resPrDb.DscRespuesta = usPrUpdateDTO.DscRespuesta;
            _usuarioRepository.ResponderPregunta(resPrDb);
            await _usuarioRepository.GuardarCambios();
        }
        public async Task<IEnumerable<UsPrDTO>> GetRespuestas(string username)
        {
            var resDbList = await _usuarioRepository.GetRespuestas(username);
            return resDbList.Select(up =>
            {
                var liLikes = up.Likes.Select(l => new LikeDTO
                {
                    LikeId = l.LikeId,
                    UsuarioPreguntasPreguntaId = l.UsuarioPreguntasPreguntaId,
                    UsuarioPreguntasUsernameConsultado = l.UsuarioPreguntasUsernameConsultado,
                    UsuarioLike = l.UsuarioLike
                }).ToList();
                return new UsPrDTO
                {
                    PreguntaId = up.PreguntaId,
                    UsernameConsultado = up.UsernameConsultado,
                    UsernameConsultante = up.UsernameConsultante ?? "Anónimo", //Si es null, lo transforma a Anónimo
                    Fecha = up.Pregunta.Fecha,
                    Dsc = up.Pregunta.Dsc,
                    FechaRespuesta = up.FechaRespuesta,
                    DscRespuesta = up.DscRespuesta,
                    LiLikes = liLikes
                };
            });
        }

        public Task DarLike()
        {
            throw new NotImplementedException();
        }

        public Task HacerPregunta()
        {
            throw new NotImplementedException();
        }
    }
}
