using love4animalss.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace love4animalss.Controllers;

[ApiController]
[Route("v1/users")] 
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet("profile")]
    public IActionResult GetUserProfile()
    {
        var user = _userService.GetUser();
        
        if (user == null)
        {
            return NotFound(new { message = "Usuario no encontrado" });
        }

        return Ok(user);
    }
}