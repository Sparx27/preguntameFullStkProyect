using Microsoft.EntityFrameworkCore;
using preguntameWebAPI.DTOs.Usuario;
using preguntameWebAPI.DTOs.UsuarioPregunta;
using preguntameWebAPI.Models;
using preguntameWebAPI.Repositories.Interfaces;

namespace preguntameWebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private AskmedbContext _context;
        public UsuarioRepository(AskmedbContext context)
        {
            _context = context;
        }

        public async Task GuardarCambios()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetUsuario(string username) => await _context.Usuarios.FindAsync(username);

        public void EditarUsuario(Usuario usuario)
        {
            _context.Usuarios.Attach(usuario);
            _context.Usuarios.Entry(usuario).State = EntityState.Modified;
        }

        public async Task<UsuarioPregunta> GetPregunta(int preguntaId, string username) =>
            await _context.UsuarioPreguntas.FindAsync(preguntaId, username);

        public async Task<List<UsuarioPregunta>> GetPreguntas(string username) =>
            await _context.UsuarioPreguntas
                            .Where(up => up.UsernameConsultado == username && up.Estado == false)
                            .Include(up => up.Pregunta).ToListAsync();

        public async Task<List<UsuarioPregunta>> GetRespuestas(string username) =>
            await _context.UsuarioPreguntas
                            .Where(up => up.UsernameConsultado == username && up.Estado == true)
                            .Include(up => up.Pregunta)
                            .Include(up => up.Likes).ToListAsync();

        public void ResponderPregunta(UsuarioPregunta usuarioPregunta)
        {
            _context.UsuarioPreguntas.Attach(usuarioPregunta);
            _context.UsuarioPreguntas.Entry(usuarioPregunta).State = EntityState.Modified;
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
