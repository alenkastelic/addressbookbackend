using AddressBook.Helpers;
using AddressBook.Infrastructure;

namespace AddressBook.Domain
{
    public class ContactMsSqlRepository : IRepository<Contact>
    {
        private readonly AddressBookDbContext dbContext;

        public ContactMsSqlRepository(AddressBookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Contact Add(Contact entity)
        {
            dbContext.Set<Contact>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(Contact entity)
        {
            dbContext.Set<Contact>().Remove(entity);
            dbContext.SaveChanges();
        }

        public FindResult<Contact> Find(Specification<Contact> spec, int pageNumber = 0, int pageSize = 100)
        {
            var results = dbContext.Set<Contact>().Where(spec.ToExpression()).ToList();
            var paginatedResults = results.Skip((pageNumber - 1) * pageSize)
                                           .Take(pageSize)
                                           .ToList();

            return new FindResult<Contact>()
            {
                Results = paginatedResults,
                TotalResults = results.Count
            };
        }

        public Contact FindById(Guid id)
        {
            return dbContext.Set<Contact>().Find(id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return dbContext.Set<Contact>();
        }

        public Contact Update(Contact entity)
        {
            dbContext.Set<Contact>().Update(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
