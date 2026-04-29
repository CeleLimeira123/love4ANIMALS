using love4animalss.Dtos;
using love4animalss.Models; // VITAL para que reconozca 'User'

namespace love4animalss.Interfaces;

public interface IUserRepository
{
    IEnumerable<GetUserDto> GetAll(); 
    
  
    User? GetById(int id); 
    
    void Add(CreateUserDto userDto);
    void Delete(int id);
}