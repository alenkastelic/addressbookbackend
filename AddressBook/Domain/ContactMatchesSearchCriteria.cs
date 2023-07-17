using System.Linq.Expressions;
using AddressBook.Helpers;

namespace AddressBook.Domain;

public class ContactMatchesSearchCriteria : Specification<Contact>
{
    private readonly string _firstName;
    private readonly string _lastName;
    private readonly string _address;
    private readonly string _phoneNumber;

    public ContactMatchesSearchCriteria(string firstName, string lastName, string address, string phoneNumber)
    {
        _firstName = firstName;
        _lastName = lastName;
        _address = address;
        _phoneNumber = phoneNumber;
    }
    
    public override Expression<Func<Contact, bool>> ToExpression()
    {
        return contact =>
            (string.IsNullOrEmpty(_firstName) || contact.FirstName.ToLower().Contains(_firstName.ToLower())) &&
            (string.IsNullOrEmpty(_lastName) || contact.LastName.ToLower().Contains(_lastName.ToLower())) &&
            (string.IsNullOrEmpty(_address) || contact.Address.ToLower().Contains(_address.ToLower())) &&
            (string.IsNullOrEmpty(_phoneNumber) || contact.PhoneNumber.Contains(_phoneNumber));
    }
}