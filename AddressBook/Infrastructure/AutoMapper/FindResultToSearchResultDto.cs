using AddressBook.Application;
using AddressBook.Domain;
using AutoMapper;

namespace AddressBook.Infrastructure.AutoMapper;

public class FindResultToSearchResultDto : Profile
{
    public FindResultToSearchResultDto()
    {
        CreateMap<FindResult<Contact>, SearchResultDto>()
            .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Results))
            .ForMember(dest => dest.TotalResults, opt => opt.MapFrom(src => src.TotalResults));
    }
}