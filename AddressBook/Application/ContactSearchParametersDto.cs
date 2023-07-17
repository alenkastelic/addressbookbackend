using System.ComponentModel.DataAnnotations;

namespace AddressBook.Application;

public class ContactSearchParametersDto
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Address { get; set; }
    
    public string PhoneNumber { get; set; }
    
    [Required]
    public int PageSize { get; set; }
    
    [Required]
    public int PageNumber { get; set; }
}