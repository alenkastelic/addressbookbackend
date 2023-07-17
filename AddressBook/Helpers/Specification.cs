using System.Linq.Expressions;

namespace AddressBook.Helpers;

public abstract class Specification<T>
{
    public bool IsSatisfiedBy(T entity)
    {
        Func<T,bool> predicate = ToExpression().Compile();
        return predicate(entity);
    }
    
    public abstract Expression<Func<T, bool>> ToExpression();
}