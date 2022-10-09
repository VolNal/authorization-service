using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VolNal.Chat.AuthorizationService.HttpModels;
using VolNal.Chat.AuthorizationService.Infrastructure.Commands;

namespace VolNal.Chat.AuthorizationService.Controllers;

[ApiController]
[Route("/api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetUserViewModel>> Get(int id)
    {
        var result = await _mediator.Send(new GetUserCommand() {Id = id});
        var resultViewModel = _mapper.Map<GetUserViewModel>(result);

        return resultViewModel;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserViewModel>> Post(CreateUserViewModel model)
    {
        var result = await _mediator.Send(_mapper.Map<CreateUserCommand>(model));
        var resultViewModel = _mapper.Map<CreateUserViewModel>(result);

        return resultViewModel;
    }
}