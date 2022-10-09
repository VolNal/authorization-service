using AutoMapper;
using VolNal.Chat.AuthorizationService.HttpModels;
using VolNal.Chat.AuthorizationService.Infrastructure.Commands;
using VolNal.Chat.AuthorizationService.Repositories.Models;

namespace VolNal.Chat.AuthorizationService.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //HttpModels => Commands
        CreateMap<GetUserViewModel, GetUserCommand>().ReverseMap();
        CreateMap<CreateUserViewModel, CreateUserCommand>().ReverseMap();

        //Commands => Dto
        CreateMap<GetUserCommand, UserDto>().ReverseMap();
        CreateMap<CreateUserCommand, UserDto>().ReverseMap();
    }
}