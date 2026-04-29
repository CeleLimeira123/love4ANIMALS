using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace love4animalss.Models;

/// <summary>
/// Representa una publicación o actualización dentro del muro de una campaña.
/// </summary>
public class Post
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(4000)] 
    public string Content { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    [Required]
    [ForeignKey("Campaign")] 
    public int CampaignId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }