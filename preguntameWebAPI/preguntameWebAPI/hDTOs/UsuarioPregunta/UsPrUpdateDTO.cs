namespace preguntameWebAPI.DTOs.UsuarioPregunta
{
    public class UsPrUpdateDTO
    {
        //FK de Pregunta
        public int PreguntaId { get; set; }

        //FK de Usuario
        public string UsernameConsultado { get; set; } = null!;

        public string DscRespuesta { get; set; } = null!;
    }
}
