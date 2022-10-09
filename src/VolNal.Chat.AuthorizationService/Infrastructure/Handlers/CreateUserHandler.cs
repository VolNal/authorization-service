using AutoMapper;
using MediatR;
using VolNal.Chat.AuthorizationService.Infrastructure.Commands;
using VolNal.Chat.AuthorizationService.Repositories.Interfaces;
using VolNal.Chat.AuthorizationService.Repositories.Models;

namespace VolNal.Chat.AuthorizationService.Infrastructure.Handlers;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateUserCommand> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserAsync(request.Name);

        if (user != null)
        {
            throw new ArgumentException("A user with the same name already exists");
        }
        
        var userDto = await _userRepository.CreateUserAsync(_mapper.Map<UserDto>(request));
        var response = _mapper.Map<CreateUserCommand>(userDto);

        return response;
    }
}