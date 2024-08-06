using System;
using System.Collections.Generic;

namespace preguntameWebAPI.Models;

public partial class Usuario
{
    public string Username { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string Correo { get; set; } = null!;

    public string UsuarioPassword { get; set; } = null!;

    public string? PaisId { get; set; }

    public string? FotoPath { get; set; }

    public decimal? Background { get; set; }

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

    public virtual Paise Pais { get; set; } = null!;

    public virtual ICollection<UsuarioPregunta> UsuarioPreguntaUsernameConsultadoNavigations { get; set; } = new List<UsuarioPregunta>();

    public virtual ICollection<UsuarioPregunta> UsuarioPreguntaUsernameConsultanteNavigations { get; set; } = new List<UsuarioPregunta>();
}
