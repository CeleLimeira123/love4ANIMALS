using love4animalss.Interfaces;
using love4animalss.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace love4animalss.Controllers;

[ApiController]
[Route("v1/users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet] 
    public IActionResult GetUsers() => Ok(_userRepository.GetAll());

    [HttpPost("register")] 
    public IActionResult Register([FromBody] CreateUserDto userDto)
    {
        if (userDto == null) return BadRequest();
        _userRepository.Add(userDto);
        return Ok(new { message = "Usuario registrado con éxito", data = userDto });
    }

    [HttpDelete("{id}")] 
    public IActionResult DeleteUser(int id)
    {
        _userRepository.Delete(id);
        return Ok(new { message = $"Usuario {id} eliminado" });
    }
}