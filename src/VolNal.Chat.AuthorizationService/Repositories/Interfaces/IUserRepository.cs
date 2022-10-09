using VolNal.Chat.AuthorizationService.Repositories.Models;

namespace VolNal.Chat.AuthorizationService.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<UserDto> GetUserAsync(int id);
    public Task<UserDto> GetUserAsync(string name);
    public Task<UserDto> CreateUserAsync(UserDto user);
}