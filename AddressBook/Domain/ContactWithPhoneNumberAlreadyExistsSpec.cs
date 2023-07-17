using System.Linq.Expressions;
using AddressBook.Helpers;
using AddressBook.Infrastructure;

namespace AddressBook.Domain;

public class ContactWithPhoneNumberAlreadyExistsSpec : Specification<Contact>
{
    private readonly string _phoneNumber;

    public ContactWithPhoneNumberAlreadyExistsSpec(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
    }
    
    public override Expression<Func<Contact, bool>> ToExpression()
        => contact => contact.PhoneNumber == _phoneNumber;
}