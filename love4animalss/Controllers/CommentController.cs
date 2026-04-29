using love4animalss.Interfaces;
using love4animalss.Models;
using love4animalss.Dtos; 
using Microsoft.AspNetCore.Mvc;

namespace love4animalss.Controllers;

[ApiController]
[Route("v1/posts/{postId}/comments")]
[Tags(" Interacción: Comentarios")]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public CommentController(ICommentRepository commentRepository, IPostRepository postRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }

    /// <summary>
    /// Lista los comentarios de un post específico.
    /// </summary>
    [HttpGet]
    [EndpointSummary("Listar comentarios")]
    [ProducesResponseType<IEnumerable<CommentDto>>(200)] 
    [ProducesResponseType(404)]
    public IActionResult GetComments(int postId)
    {
        var post = _postRepository.GetById(postId);
        if (post == null) return NotFound(new { message = "El post indicado no existe." });

        var comments = _commentRepository.GetByPostId(postId);
        return Ok(comments);
    }

    /// <summary>
    /// Crea un comentario validando que el post exista.
    /// </summary>
    [HttpPost]
    [EndpointSummary("Crear comentario")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult CreateComment(int postId, [FromBody] CommentRequestDto dto)
    {
        var post = _postRepository.GetById(postId);
        if (post == null) return NotFound(new { message = "Post no encontrado" });

        if (!ModelState.IsValid) return BadRequest(ModelState);

        var newComment = new Comment 
        { 
            PostId = postId, 
            Text = dto.Text,
            CreatedAt = DateTime.UtcNow 
        };

        _commentRepository.Add(newComment);
        return CreatedAtAction(nameof(GetComments), new { postId = postId }, new { message = "Comentario creado", data = newComment });
    }

    [HttpPut("{commentId}")]
    [EndpointSummary("Actualizar comentario")]
    public IActionResult UpdateComment(int postId, int commentId, [FromBody] CommentRequestDto dto)
    {
        var existing = _commentRepository.GetById(postId, commentId);
        if (existing == null) return NotFound();

        if (!ModelState.IsValid) return BadRequest(ModelState);

        existing.Text = dto.Text;
        _commentRepository.Update(existing);
        return Ok(new { message = "Actualizado", data = existing });
    }

    [HttpDelete("{commentId}")]
    [EndpointSummary("Eliminar comentario")]
    public IActionResult DeleteComment(int postId, int commentId)
    {
        var existing = _commentRepository.GetById(postId, commentId);
        if (existing == null) return NotFound();

        _commentRepository.Delete(commentId);
        return Ok(new { message = "Eliminado" });
    }
}