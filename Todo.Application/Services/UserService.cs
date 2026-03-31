using Todo.Application.DTO;
using Todo.Domain.Interfaces;

namespace Todo.Application.Services;

public class UserService
{
    private IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void CreateUser(CreateUserDto userDto)
    {
        var user = new Domain.Entities.User()
        {
            Username = userDto.Username,
            Email = userDto.Email
        };

        _userRepository.Add(user);
    }

    public UserDto GetById(int id)
    {
        var user = _userRepository.GetById(id);

        var dto = new UserDto()
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username
        };
        return dto;
    }
}