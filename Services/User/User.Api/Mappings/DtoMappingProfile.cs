using AutoMapper;
using User.Application.Dto.Address;
using User.Application.Dto.PhoneNumber;
using User.Application.Dto.User;
using User.Core.Entities;

namespace User.Api.Mappings
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Core.Entities.User, UserDto>();
            CreateMap<Core.Entities.Address, AddressDto>();
            CreateMap<PhoneNumber, PhoneNumberDto>();
        }
    }
}