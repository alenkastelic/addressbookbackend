using AddressBook.Application;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }
        
        [HttpGet("getContacts")]
        public List<ContactDto> GetContacts()
        {
            return _contactService.GetContacts();
        }

        [HttpGet("getById/{id}")]
        public ContactDto GetById(string id)
        {
            return _contactService.GetById(new Guid(id));
        }

        [HttpGet("search")]
        public SearchResultDto SearchContacts([FromQuery]ContactSearchParametersDto searchParametersDto)
        {
            return _contactService.Search(searchParametersDto);
        }

        [HttpGet("doesPhoneNumberExists/{phoneNumber}")]
        public bool DoesPhoneNumberExists(string phoneNumber)
        {
            return _contactService.ContactAlreadyExists(phoneNumber);
        }

        [HttpPost("add")]
        public void Add(ContactDataDto contactDataDto)
        {
            this._contactService.Add(contactDataDto);
        }

        [HttpPut("edit/{id}")]
        public void Edit(string id, ContactDataDto contactDto)
        {
            this._contactService.Update(new Guid(id), contactDto);
        }

        [HttpDelete("delete/{contactId}")]
        public void Delete(string contactId)
        {
            this._contactService.Delete(new Guid(contactId));
        }
    }
}
