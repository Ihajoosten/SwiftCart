using AutoMapper;
using User.Application.Dto.Address;
using User.Application.Dto.PhoneNumber;
using User.Application.Dto.User;
using User.Core.Entities;

namespace User.Api.Mappings
{
    public class CreateDtoMappingProfile : Profile
    {
        public CreateDtoMappingProfile()
        {
            CreateMap<CreateUserDto, Core.Entities.User>();
            CreateMap<CreateAddressDto, Core.Entities.Address>();
            CreateMap<CreatePhoneNumberDto, PhoneNumber>();
        }
    }
}