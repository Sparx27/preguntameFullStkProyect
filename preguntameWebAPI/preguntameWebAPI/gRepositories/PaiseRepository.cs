using Microsoft.EntityFrameworkCore;
using preguntameWebAPI.Models;
using preguntameWebAPI.Repositories.Interfaces;

namespace preguntameWebAPI.Repositories
{
    public class PaiseRepository : IPaiseRepository<Paise>
    {
        private AskmedbContext _context;
        public PaiseRepository(AskmedbContext context)
        {
            _context = context;
        }
        public async Task<List<Paise>> GetAll() => await _context.Paises.ToListAsync();

        public async Task<Paise> GetByCode(string code) => await _context.Paises.FindAsync(code);
    }
}
