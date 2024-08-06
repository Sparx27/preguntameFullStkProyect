using preguntameWebAPI.DTOs;

namespace preguntameWebAPI.Services.Interfaces
{
    public interface IPaiseService
    {
        Task<IEnumerable<PaiseDTO>> GetAll();
        Task<PaiseDTO> GetByCode(string code);
    }
}
