using Auth.Application.Dto.Auth;
using AutoMapper;

namespace Auth.Api.Mappings
{
    public class CreateDtoMappingProfile : Profile
    {
        public CreateDtoMappingProfile()
        {
            CreateMap<RegisterDto, Core.Entities.User>();
        }
    }
}