namespace preguntameWebAPI.Repositories.Interfaces
{
    public interface IPaiseRepository<Paise>
    {
        Task<List<Paise>> GetAll();
        Task<Paise> GetByCode(string code);
    }
}
