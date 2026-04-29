using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace love4animalss.Models;

/// <summary>
/// Representa un comentario realizado por un usuario en una publicación.
/// </summary>
public class Comment
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(500)] 
    public string Text { get; set; } = string.Empty;

    [Required]
    [ForeignKey("Post")] 
    public int PostId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}