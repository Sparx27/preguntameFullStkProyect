using System;
using System.Collections.Generic;

namespace preguntameWebAPI.Models;

public partial class Paise
{
    public string PaisId { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
