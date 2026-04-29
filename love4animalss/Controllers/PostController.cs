using love4animalss.Interfaces;
using love4animalss.Models;
using love4animalss.Dtos; 
using Microsoft.AspNetCore.Mvc;

namespace love4animalss.Controllers;

[ApiController]
[Route("v1/posts")]
[Tags(" Muro de Publicaciones")] 
public class PostController : ControllerBase
{
    private readonly IPostRepository _postRepository;

    public PostController(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    /// <summary>
    /// Obtiene todas las publicaciones de las campañas de ayuda.
    /// </summary>
    [HttpGet]
    [EndpointSummary("Listar todas las publicaciones")]
    [ProducesResponseType<IEnumerable<GetPostDto>>(200)]
    public IActionResult GetPosts() 
    {
        return Ok(_postRepository.GetAll());
    }

    /// <summary>
    /// Crea una nueva publicación vinculada a una campaña.
    /// </summary>
    /// <param name="postDto">Datos de la publicación.</param>
    [HttpPost]
    [EndpointSummary("Crear nuevo post")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult CreatePost([FromBody] CreatePostDto postDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var newPost = new Post 
        { 
            Title = postDto.Title, 
            Content = postDto.Content, 
            ImageUrl = postDto.ImageUrl, 
            CampaignId = postDto.CampaignId 
        };

        _postRepository.Add(newPost);
        
        return CreatedAtAction(nameof(GetPosts), new { message = "Post publicado con éxito", data = newPost });
    }

    /// <summary>
    /// Actualiza el contenido de un post existente.
    /// </summary>
    /// <param name="id">ID del post a modificar.</param>
    /// <param name="postDto">Nuevos datos del post.</param>
    [HttpPut("{id}")]
    [EndpointSummary("Actualizar publicación")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult UpdatePost(int id, [FromBody] UpdatePostDto postDto)
    {
        var existing = _postRepository.GetById(id);
        if (existing == null) 
            return NotFound(new { message = $"Post {id} no encontrado" });

        if (!ModelState.IsValid) return BadRequest(ModelState);

        existing.Title = postDto.Title;
        existing.Content = postDto.Content;
        existing.ImageUrl = postDto.ImageUrl;

        _postRepository.Update(existing);
        
        return Ok(new { message = "Post actualizado con éxito", data = existing });
    }

    /// <summary>
    /// Elimina un post permanentemente mediante su ID.
    /// </summary>
    [HttpDelete("{id}")]
    [EndpointSummary("Eliminar publicación")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult DeletePost(int id)
    {
        var existing = _postRepository.GetById(id);
        if (existing == null) 
            return NotFound(new { message = $"Post {id} no encontrado" });

        _postRepository.Delete(id);
        return Ok(new { message = $"Post {id} eliminado" });
    }
}