using love4animalss.Interfaces;
using love4animalss.Dtos;
using love4animalss.Models;
using Microsoft.AspNetCore.Mvc;

namespace love4animalss.Controllers;

[ApiController]
[Route("v1/users/profile")]
public class PostController : ControllerBase
{
    private readonly IPostRepository _postRepository;

    public PostController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    [HttpGet] 
    public IActionResult GetPosts() => Ok(_postRepository.GetAll());

    [HttpPost] 
    public IActionResult CreatePost([FromBody] CreatePostDto postDto)
    {
        if (postDto == null) return BadRequest();

        var newPost = new Post 
        { 
            Title = postDto.Title, 
            Content = postDto.Content, 
            CampaignId = postDto.CampaignId 
        };

        _postRepository.Add(newPost);
        return Ok(new { message = "Post creado con éxito", data = newPost });
    }

    [HttpDelete("{id}")] 
    public IActionResult DeletePost(int id)
    {
        var existing = _postRepository.GetById(id);
        if (existing == null) 
            return NotFound(new { message = $"Post {id} no encontrado" });

        _postRepository.Delete(id);
        return Ok(new { message = $"Post {id} eliminado" });
    }
    [HttpPut("{id}")]
public IActionResult UpdatePost(int id, [FromBody] UpdatePostDto postDto)
{
    var existing = _postRepository.GetById(id);
    if (existing == null) 
        return NotFound(new { message = $"Post {id} no encontrado" });

    existing.Title = postDto.Title;
    existing.Content = postDto.Content;

    _postRepository.Update(existing);
    
    return Ok(new { 
        message = "Post actualizado con éxito", 
        data = existing 
    });
}
}