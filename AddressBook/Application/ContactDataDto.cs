using System.ComponentModel.DataAnnotations;

namespace AddressBook.Application;

public class ContactDataDto
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string PhoneNumber { get; set; }
}