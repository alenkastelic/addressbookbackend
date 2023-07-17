using AddressBook.Application;
using AddressBook.Domain;
using AutoMapper;

namespace AddressBook.Infrastructure.AutoMapper;

public class ContactToContactDto : Profile
{
    public ContactToContactDto()
    {
        CreateMap<Contact, ContactDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
    }
}