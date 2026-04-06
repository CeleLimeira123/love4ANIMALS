using love4animalss.Dtos;
using love4animalss.Interfaces;
using love4animalss.Models;

namespace love4animalss.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users;

    public UserRepository()
    {
        _users = new List<User>
        {
            new User { Id = 1, Name = "Celeste Limeira", Email = "celeste@ucb.edu.bo" }
        };
    }

    public IEnumerable<GetUserDto> GetAll() 
    {
        return _users.Select(u => new GetUserDto(u.Id, u.Name, u.Email));
    }

    public void Add(CreateUserDto userDto)
    {
        var newId = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
        _users.Add(new User { Id = newId, Name = userDto.Name, Email = userDto.Email });
    }

    public void Delete(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user != null) _users.Remove(user);
    }
}