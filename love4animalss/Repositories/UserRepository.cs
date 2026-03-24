using love4animalss.Interfaces;
using love4animalss.Models; 

namespace love4animalss.Repositories;

public class UserRepository : IUserRepository
{
    private readonly User _user;

    public UserRepository()
    {
       
        _user = new User 
        { 
            Id = 1, 
            Name = "Celeste", 
            Email = "celeste@ucb.edu.bo" 
        };
    }

    public User getUser()
    {
        return _user;
    }
}