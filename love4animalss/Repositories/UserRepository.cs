using love4animalss.Interfaces;
using love4animalss.Models;

namespace love4animalss.Repositories;

public class UserRepository : IUserRepository
{
    private List<User> Users { get; set; }

    public UserRepository()
    {
        this.Users = new List<User>();
         User newUser = new User(1, "Celeste", "test@gmail.com");
        
        this.Users.Add(newUser);
    }

    public User getUser()
    {
         return this.Users.First();
    }
}