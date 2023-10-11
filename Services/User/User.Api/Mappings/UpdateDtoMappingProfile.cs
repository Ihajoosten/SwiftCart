using AutoMapper;
using User.Application.Dto.Address;
using User.Application.Dto.PhoneNumber;
using User.Application.Dto.User;
using User.Core.Entities;

namespace User.Api.Mappings
{
    public class UpdateDtoMappingProfile : Profile
    {
        public UpdateDtoMappingProfile()
        {
            CreateMap<UpdateUserDto, Core.Entities.User>();
            CreateMap<UpdateAddressDto, Core.Entities.Address>();
            CreateMap<UpdatePhoneNumberDto, PhoneNumber>();
        }
    }
}