using AddressBook.Domain;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure
{
    public class AddressBookDbContext : DbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options)
           : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}
