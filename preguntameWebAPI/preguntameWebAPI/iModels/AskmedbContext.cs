using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace preguntameWebAPI.Models;

public partial class AskmedbContext : DbContext
{
    public AskmedbContext(DbContextOptions<AskmedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Pregunta> Preguntas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioPregunta> UsuarioPreguntas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => new { e.LikeId, e.UsuarioPreguntasPreguntaId, e.UsuarioPreguntasUsernameConsultado });

            entity.Property(e => e.LikeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("likeId");
            entity.Property(e => e.UsuarioPreguntasPreguntaId).HasColumnName("usuarioPreguntas_preguntaId");
            entity.Property(e => e.UsuarioPreguntasUsernameConsultado)
                .HasMaxLength(20)
                .HasColumnName("usuarioPreguntas_usernameConsultado");
            entity.Property(e => e.UsuarioLike)
                .HasMaxLength(20)
                .HasColumnName("usuario_like");

            entity.HasOne(d => d.UsuarioLikeNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UsuarioLike)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuLike");

            entity.HasOne(d => d.UsuarioPregunta).WithMany(p => p.Likes)
                .HasForeignKey(d => new { d.UsuarioPreguntasPreguntaId, d.UsuarioPreguntasUsernameConsultado })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_preguntaUsuarioLike");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.PaisId);

            entity.Property(e => e.PaisId)
                .HasMaxLength(2)
                .HasColumnName("paisId");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.Property(e => e.PreguntaId).HasColumnName("preguntaId");
            entity.Property(e => e.Dsc)
                .HasMaxLength(1000)
                .HasColumnName("dsc");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK_Usuario");

            entity.HasIndex(e => e.Correo, "AK_correo").IsUnique();

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");
            entity.Property(e => e.Apellido)
                .HasMaxLength(30)
                .HasColumnName("apellido");
            entity.Property(e => e.Background)
                .HasColumnType("numeric(5, 0)")
                .HasColumnName("background");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .HasColumnName("correo");
            entity.Property(e => e.FotoPath)
                .HasMaxLength(255)
                .HasColumnName("foto_path");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .HasColumnName("nombre");
            entity.Property(e => e.PaisId)
                .HasMaxLength(2)
                .HasColumnName("paisId");
            entity.Property(e => e.UsuarioPassword)
                .HasMaxLength(20)
                .HasColumnName("usuario_password");

            entity.HasOne(d => d.Pais).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuPais");
        });

        modelBuilder.Entity<UsuarioPregunta>(entity =>
        {
            entity.HasKey(e => new { e.PreguntaId, e.UsernameConsultado }).HasName("FK_usuarioPreguntas");

            entity.Property(e => e.PreguntaId).HasColumnName("preguntaId");
            entity.Property(e => e.UsernameConsultado)
                .HasMaxLength(20)
                .HasColumnName("usernameConsultado");
            entity.Property(e => e.DscRespuesta)
                .HasMaxLength(1000)
                .HasColumnName("dscRespuesta");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaRespuesta)
                .HasColumnType("datetime")
                .HasColumnName("fechaRespuesta");
            entity.Property(e => e.UsernameConsultante)
                .HasMaxLength(20)
                .HasColumnName("usernameConsultante");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.UsuarioPregunta)
                .HasForeignKey(d => d.PreguntaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_preguntaId");

            entity.HasOne(d => d.UsernameConsultadoNavigation).WithMany(p => p.UsuarioPreguntaUsernameConsultadoNavigations)
                .HasForeignKey(d => d.UsernameConsultado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usernameConsultado");

            entity.HasOne(d => d.UsernameConsultanteNavigation).WithMany(p => p.UsuarioPreguntaUsernameConsultanteNavigations)
                .HasForeignKey(d => d.UsernameConsultante)
                .HasConstraintName("FK_usernameConsultante");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
