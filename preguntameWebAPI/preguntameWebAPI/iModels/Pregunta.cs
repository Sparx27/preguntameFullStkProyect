using System;
using System.Collections.Generic;

namespace preguntameWebAPI.Models;

public partial class Pregunta
{
    public int PreguntaId { get; set; }

    public string Dsc { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual ICollection<UsuarioPregunta> UsuarioPregunta { get; set; } = new List<UsuarioPregunta>();
}
