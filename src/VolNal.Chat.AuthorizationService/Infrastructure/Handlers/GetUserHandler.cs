using AutoMapper;
using MediatR;
using VolNal.Chat.AuthorizationService.Infrastructure.Commands;
using VolNal.Chat.AuthorizationService.Repositories.Interfaces;

namespace VolNal.Chat.AuthorizationService.Infrastructure.Handlers;

public class GetUserHandler : IRequestHandler<GetUserCommand, GetUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserCommand> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var resp = await _userRepository.GetUserAsync(request.Id);

        if (resp == null)
        {
            throw new NullReferenceException($"User with specified id not found");
        }

        var response = _mapper.Map<GetUserCommand>(resp);

        return response;
    }
}