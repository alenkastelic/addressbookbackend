namespace AddressBook.Application;

public class SearchResultDto
{
    public List<ContactDto> Contacts { get; set; }

    public int TotalResults { get; set; }
}