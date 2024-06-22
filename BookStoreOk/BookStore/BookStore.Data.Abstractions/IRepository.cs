namespace BookStore.Data.Abstractions
{
  public interface IRepository<T>
  {
    Task<bool> InsertAsync(T item, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(T item, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(int count,CancellationToken cancellationToken);
    Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);
  }
}
