using preguntameWebAPI.hDTOs;
using preguntameWebAPI.Models;

namespace preguntameWebAPI.DTOs.UsuarioPregunta
{
    public class UsPrDTO
    {
        //PK
        public int PreguntaId { get; set; }

        //PK/FK de UsernameConsultado ira implicto con el manejo de sesion
        public string UsernameConsultado { get; set; } = null!;

        //FK en caso de un Usuario hace pregunta
        public string? UsernameConsultante { get; set; }
        public DateTime Fecha { get; set; }
        public string Dsc {  get; set; }
        public string? DscRespuesta { get; set; }
        public DateTime? FechaRespuesta { get; set; }
        public IEnumerable<LikeDTO> LiLikes { get; set; } = new List<LikeDTO>();
    }
}
