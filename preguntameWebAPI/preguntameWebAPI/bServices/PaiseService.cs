using preguntameWebAPI.Models;
using preguntameWebAPI.DTOs;
using preguntameWebAPI.Repositories.Interfaces;
using preguntameWebAPI.Services.Interfaces;

namespace preguntameWebAPI.Services
{
    public class PaiseService : IPaiseService
    {
        private IPaiseRepository<Paise> _repository;
        public PaiseService(IPaiseRepository<Paise> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PaiseDTO>> GetAll()
        {
            var dbRes = await _repository.GetAll();
            return dbRes.Select(p => new PaiseDTO
            {
                PaisId = p.PaisId,
                Nombre = p.Nombre
            });
        }

        public async Task<PaiseDTO> GetByCode(string code)
        {
            var dbRes = await _repository.GetByCode(code);
            if (dbRes == null) return null;
            return new PaiseDTO
            {
                PaisId = dbRes.PaisId,
                Nombre = dbRes.Nombre
            };
        }
    }
}
