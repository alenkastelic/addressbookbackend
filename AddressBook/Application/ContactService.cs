using AddressBook.Domain;
using AddressBook.Helpers;
using AddressBook.Infrastructure;
using AutoMapper;

namespace AddressBook.Application;

public interface IContactService
{
    List<ContactDto> GetContacts();
    void Add(ContactDataDto contactDataDto);
    ContactDto GetById(Guid id);
    void Update(Guid id, ContactDataDto contactDto);
    void Delete(Guid id);
    bool ContactAlreadyExists(string phoneNumber);
    SearchResultDto Search(ContactSearchParametersDto searchParameters);
}

public class ContactService : IContactService
{
    private readonly IRepository<Contact> _contactRepository;
    private readonly IMapper _mapper;

    public ContactService(IRepository<Contact> contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public List<ContactDto> GetContacts()
    {
        return _mapper.Map<List<ContactDto>>(_contactRepository.GetAll().ToList());
    }

    public ContactDto GetById(Guid id)
    {
        Contact contact = _contactRepository.FindById(id);
        return _mapper.Map<Contact, ContactDto>(contact);
    }

    public void Add(ContactDataDto contactDataDto)
    {
        if (ContactAlreadyExists(contactDataDto.PhoneNumber))
        {
            throw new Exception("Customer with phone number already exists!");
        }

        ContactInformation contactInformation = new ContactInformation(
            contactDataDto.FirstName, contactDataDto.LastName, contactDataDto.Address, contactDataDto.PhoneNumber);

        Contact contact = Contact.Create(contactInformation);
        _contactRepository.Add(contact);
    }

    public void Update(Guid id, ContactDataDto contactDataDto)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("Missing contact id");
        }

        Contact contact = _contactRepository.FindById(id);
        ContactInformation contactInformation = new ContactInformation(
            contactDataDto.FirstName, contactDataDto.LastName, contactDataDto.Address, contactDataDto.PhoneNumber);
        contact.UpdateContactInformation(contactInformation);
        _contactRepository.Update(contact);
    }

    public void Delete(Guid contactId)
    {
        Contact contact = _contactRepository.FindById(contactId);
        if (contact != null)
        {
            _contactRepository.Delete(contact);
        }
    }

    public bool ContactAlreadyExists(string phoneNumber)
    {
        var phoneNumberAlreadyExistsSpec = new ContactWithPhoneNumberAlreadyExistsSpec(phoneNumber);
        return _contactRepository.Find(phoneNumberAlreadyExistsSpec).TotalResults > 0;
    }

    public SearchResultDto Search(ContactSearchParametersDto searchParameters)
    {
        var specification = new ContactMatchesSearchCriteria(searchParameters.FirstName, searchParameters.LastName,
            searchParameters.Address, searchParameters.PhoneNumber);
        var contactSerchResults = _contactRepository.Find(specification,
            searchParameters.PageNumber, searchParameters.PageSize);
        return _mapper.Map<SearchResultDto>(contactSerchResults);
    }
}