using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Domain;

public class Contact
{
    public Guid Id { get; private set; }
    
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
    
    public string Address { get; private set; }
    
    public string PhoneNumber { get; private set; }

    private Contact()
    {
    }

    public void UpdateContactInformation(ContactInformation contactInformation)
    {
        FirstName = contactInformation.FirstName;
        LastName = contactInformation.Lastname;
        Address = contactInformation.Address;
        PhoneNumber = contactInformation.PhoneNumber;
    }

    public static Contact Create(ContactInformation contactInformation)
    {
        if (string.IsNullOrEmpty(contactInformation.FirstName))
        {
            throw new ArgumentNullException(nameof(contactInformation.FirstName));
        }

        if (string.IsNullOrEmpty(contactInformation.Lastname))
        {
            throw new ArgumentNullException(nameof(contactInformation.Lastname));
        }

        if (string.IsNullOrEmpty(contactInformation.Address))
        {
            throw new ArgumentNullException(nameof(contactInformation.Address));
        }

        if (string.IsNullOrEmpty(contactInformation.PhoneNumber))
        {
            throw new ArgumentNullException(nameof(contactInformation.PhoneNumber));
        }

        return new Contact
        {
            Id = Guid.NewGuid(),
            FirstName = contactInformation.FirstName,
            LastName = contactInformation.Lastname,
            Address = contactInformation.Address,
            PhoneNumber = contactInformation.PhoneNumber
        };
    }
}