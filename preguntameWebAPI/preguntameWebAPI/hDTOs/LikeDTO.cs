using preguntameWebAPI.Models;

namespace preguntameWebAPI.hDTOs
{
    public class LikeDTO
    {
        //Pk
        public int LikeId { get; set; }
        //PK preguntaId
        public int UsuarioPreguntasPreguntaId { get; set; }
        //PK username
        public string UsuarioPreguntasUsernameConsultado { get; set; } = null!;

        //Obligatorio para generar el like y asociarlo a otro usuario
        public string UsuarioLike { get; set; } = null!;
    }
}
