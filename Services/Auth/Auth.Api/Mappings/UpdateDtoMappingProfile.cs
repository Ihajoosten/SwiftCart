using Auth.Application.Dto.Auth;
using AutoMapper;

namespace Auth.Api.Mappings
{
    public class UpdateDtoMappingProfile : Profile
    {
        public UpdateDtoMappingProfile()
        {
            CreateMap<UpdateCredentialsDto, Core.Entities.User>();
        }
    }
}