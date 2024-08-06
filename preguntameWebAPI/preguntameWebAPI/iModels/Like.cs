using System;
using System.Collections.Generic;

namespace preguntameWebAPI.Models;

public partial class Like
{
    public int LikeId { get; set; }

    public int UsuarioPreguntasPreguntaId { get; set; }

    public string UsuarioPreguntasUsernameConsultado { get; set; } = null!;

    public string UsuarioLike { get; set; } = null!;

    public virtual Usuario UsuarioLikeNavigation { get; set; } = null!;

    public virtual UsuarioPregunta UsuarioPregunta { get; set; } = null!;
}
