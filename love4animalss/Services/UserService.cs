using love4animalss.Dtos;
using love4animalss.Interfaces;
using love4animalss.Models;

namespace love4animalss.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
public GetUserDto GetUserProfile() 
    {
        
        var allUsers = _userRepository.GetAll();
        var getUser = allUsers.First(); 

        var response = new GetUserDto(
            getUser.Id, 
            getUser.Name, 
            getUser.Email
        );

        return response;
    }
    public void CreateUser(CreateUserDto userDto)
    {
      
        Console.WriteLine($"Preparando registro para: {userDto.Name}");
    }
}