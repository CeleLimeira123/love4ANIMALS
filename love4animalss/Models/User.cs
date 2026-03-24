
using System;

namespace love4animalss.Models;

public class User
{
    public User (int Id, string Name, string Email)
    {
        this.Id = Id;
        this.Name = Name;
        this.Email = Email;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

}
