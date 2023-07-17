using AddressBook.Helpers;
using AddressBook.Infrastructure;

namespace AddressBook.Domain;

public class ContactInMemoryRepository : IRepository<Contact>
{
    private static readonly List<Contact> Entities = new List<Contact>();

    public ContactInMemoryRepository()
    {
        if (!Entities.Any())
        {
            Entities.Add(Contact.Create(new ContactInformation("Rick", "Sanchez", "Citadel 1", "+38631111111")));
            Entities.Add(Contact.Create(new ContactInformation("Mort", "Smith", "Citadel 1", "+38631111111")));
            Entities.Add(Contact.Create(new ContactInformation("Summer", "Smith", "Citadel 2", "+38632222222")));
            Entities.Add(Contact.Create(new ContactInformation("Beth", "Smith", "Citadel 2", "+38632222222")));
            Entities.Add(Contact.Create(new ContactInformation("Jerry", "Smith", "Citadel 3", "+38633333333")));
            Entities.Add(Contact.Create(new ContactInformation("Birdperson", "", "Citadel 3", "+38633333333")));
            Entities.Add(Contact.Create(new ContactInformation("Mr. Meeseeks", "", "Citadel 4", "+38634444444")));
            Entities.Add(Contact.Create(new ContactInformation("Squanchy", "", "Citadel 4", "+38634444444")));
            Entities.Add(Contact.Create(new ContactInformation("Unity", "", "Citadel 5", "+38635555555")));
            Entities.Add(Contact.Create(new ContactInformation("Noob-Noob", "", "Citadel 5", "+38635555555")));
            Entities.Add(Contact.Create(new ContactInformation("Evil Morty", "", "Citadel 6", "+38636666666")));
            Entities.Add(Contact.Create(new ContactInformation("Tammy", "Gueterman", "Citadel 6", "+38636666666")));
            Entities.Add(Contact.Create(new ContactInformation("Pickle Rick", "", "Citadel 7", "+38637777777")));
            Entities.Add(Contact.Create(new ContactInformation("Scary Terry", "", "Citadel 7", "+38637777777")));
            Entities.Add(Contact.Create(new ContactInformation("Abradolf", "Lincler", "Citadel 8", "+38638888888")));
            Entities.Add(Contact.Create(new ContactInformation("Snowball", "", "Citadel 8", "+38638888888")));
            Entities.Add(Contact.Create(new ContactInformation("Michael", "Krombopulos", "Citadel 9", "+38639999999")));
            Entities.Add(Contact.Create(new ContactInformation("Morty Jr.", "", "Citadel 9", "+38639999999")));
            Entities.Add(Contact.Create(new ContactInformation("Gazorpazorpfield", "", "Citadel 10", "+38630000000")));
            Entities.Add(Contact.Create(new ContactInformation("Jessica", "", "Citadel 10", "+38630000000")));
        }
    }
    public Contact FindById(Guid id)
    {
        return Entities.FirstOrDefault(contact => contact.Id == id);
    }
    
    public FindResult<Contact> Find(Specification<Contact> spec, int pageNumber = 0, int pageSize = 100)
    {
        var results = Entities.AsQueryable().Where(spec.ToExpression());
        var paginatedResults = results
                                            .Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();
        return new FindResult<Contact>()
        {
            Results = paginatedResults,
            TotalResults = results.Count()
        };
    }
    
    public Contact Add(Contact entity)
    {
        Entities.Add(entity);
        return entity;
    }

    public Contact Update(Contact entity)
    {
        Delete(entity);
        Entities.Add(entity);
        return entity;
    }

    public void Delete(Contact entity)
    {
        Entities.RemoveAll(contact => contact.Id == entity.Id);
    }

    public IEnumerable<Contact> GetAll()
    {
        return Entities;
    }
}