using AddressBook.Domain;

namespace AddressBook.Infrastructure
{
    public class DataSeeder
    {
        private readonly AddressBookDbContext dbContext;

        public DataSeeder(AddressBookDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Seed()
        {
            if (dbContext.Contacts.Any())
            {
                return;
            }

            var contacts = new List<Contact>();
            for (int i = 0; i < 30; i++)
            {
                string[] names = { "John", "Jane", "Michael", "Emily", "David", "Sarah" }; 
                string[] surnames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis" }; 
                string[] addresses = { "123 Main St", "456 Elm St", "789 Oak Ave", "10 Pine Rd", "111 Maple Ln" }; 

                string name = names[new Random().Next(names.Length)];
                string surname = surnames[new Random().Next(surnames.Length)];
                string address = addresses[new Random().Next(addresses.Length)];
                string phoneNumber = GenerateRandomPhoneNumber();

                contacts.Add(Contact.Create(new ContactInformation(name, surname, address, phoneNumber)));
            }

            dbContext.Contacts.AddRange(contacts);
            dbContext.SaveChanges();
        }

        private string GenerateRandomPhoneNumber()
        {
            Random random = new Random();
            string phoneNumber = "+386";

            for (int i = 0; i < 8; i++)
            {
                phoneNumber += random.Next(10).ToString();
            }

            return phoneNumber;
        }
    }
}
