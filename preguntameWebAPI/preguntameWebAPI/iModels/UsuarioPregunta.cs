using System;
using System.Collections.Generic;

namespace preguntameWebAPI.Models;

public partial class UsuarioPregunta
{
    //FK de Pregunta
    public int PreguntaId { get; set; }

    //FK de Usuario
    public string UsernameConsultado { get; set; }

    //FK en caso de un Usuario hace pregunta
    public string? UsernameConsultante { get; set; }

    public bool Estado { get; set; } = false;

    public string? DscRespuesta { get; set; }

    public DateTime? FechaRespuesta { get; set; }

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual Pregunta Pregunta { get; set; } = null!;

    public virtual Usuario UsernameConsultadoNavigation { get; set; } = null!;

    public virtual Usuario? UsernameConsultanteNavigation { get; set; }
}
