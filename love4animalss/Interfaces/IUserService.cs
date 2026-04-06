using love4animalss.Dtos; 
using love4animalss.Models;

namespace love4animalss.Interfaces;

public interface IUserService
{
    GetUserDto GetUserProfile(); 
    void CreateUser(CreateUserDto userDto); 
}