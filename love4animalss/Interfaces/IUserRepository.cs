using love4animalss.Dtos;

namespace love4animalss.Interfaces;

public interface IUserRepository
{
    IEnumerable<GetUserDto> GetAll(); 
    void Add(CreateUserDto userDto);
    void Delete(int id);
}