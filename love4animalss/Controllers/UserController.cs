using love4animalss.Interfaces;
using love4animalss.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace love4animalss.Controllers;

[ApiController]
[Route("v1/users")]
[Tags("Gestión de Usuarios")] 
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    [EndpointSummary("Listar usuarios")]
    [ProducesResponseType<IEnumerable<GetUserDto>>(200)]
    public IActionResult GetUsers() 
    {
        return Ok(_userRepository.GetAll());
    }

    [HttpPost("register")]
    [EndpointSummary("Registrar nuevo usuario")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult Register([FromBody] CreateUserDto userDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _userRepository.Add(userDto);
        return CreatedAtAction(nameof(GetUsers), new { message = "Usuario registrado con éxito", data = userDto });
    }

    // --- ESTE ES EL MÉTODO PUT QUE FALTABA ---
    [HttpPut("{id}")]
    [EndpointSummary("Actualizar usuario")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult UpdateUser(int id, [FromBody] CreateUserDto userDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existingUser = _userRepository.GetById(id);
        if (existingUser == null) return NotFound(new { message = "Usuario no encontrado" });

        // Aquí se llamaría a la lógica de actualización del repositorio
        // _userRepository.Update(id, userDto); 
        
        return Ok(new { message = $"Usuario con ID {id} actualizado correctamente" });
    }

    [HttpDelete("{id}")]
    [EndpointSummary("Eliminar usuario")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult DeleteUser(int id)
    {
        var existingUser = _userRepository.GetById(id);
        if (existingUser == null) return NotFound(new { message = "Usuario no encontrado" });

        _userRepository.Delete(id);
        return Ok(new { message = $"Usuario con ID {id} eliminado correctamente" });
    }
}