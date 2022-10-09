using MediatR;

namespace VolNal.Chat.AuthorizationService.Infrastructure.Commands;

public class CreateUserCommand : IRequest<CreateUserCommand>
{
    public int Id { get; set; }
    public string Name { get; set; }
}