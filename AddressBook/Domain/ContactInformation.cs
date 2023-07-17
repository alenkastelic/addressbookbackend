namespace AddressBook.Domain;

public class ContactInformation
{
    public ContactInformation(string firstName, string lastname, string address, string phoneNumber)
    {
        FirstName = firstName;
        Lastname = lastname;
        Address = address;
        PhoneNumber = phoneNumber;
    }

    public string FirstName { get; set; }
    
    public string Lastname { get; set; }
    
    public string Address { get; set; }
    
    public string PhoneNumber { get; set; }
}