namespace preguntameWebAPI.Repositories.Interfaces
{
    public interface ICRUD<TEntity>
    {
        Task<TEntity> Get(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
        Task Save();
    }
}
