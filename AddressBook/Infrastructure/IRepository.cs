using AddressBook.Helpers;

namespace AddressBook.Infrastructure;

public interface IRepository<TEntity>
{
    TEntity FindById(Guid id);

    FindResult<TEntity> Find(Specification<TEntity> spec, int pageNumber = 0, int pageSize = 100);
    
    TEntity Add(TEntity entity);

    TEntity Update(TEntity entity);

    void Delete(TEntity entity);

    IEnumerable<TEntity> GetAll();
}

public class FindResult<TEntity>
{
    public IReadOnlyList<TEntity> Results { get; set; }
    
    public int TotalResults { get; set; }
}