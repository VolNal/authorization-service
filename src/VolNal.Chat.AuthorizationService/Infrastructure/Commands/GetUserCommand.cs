using MediatR;

namespace VolNal.Chat.AuthorizationService.Infrastructure.Commands;

public class GetUserCommand : IRequest<GetUserCommand>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
