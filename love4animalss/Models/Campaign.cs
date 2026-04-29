using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace love4animalss.Models;

/// <summary>
/// Representa una campaña de recaudación o ayuda dentro del sistema Love4Animals.
/// </summary>
public class Campaign
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")] 
    public decimal GoalAmount { get; set; }

    
    public Campaign() { }

    public Campaign(int id, string title, string description, decimal goalAmount)
    {
        Id = id;
        Title = title;
        Description = description;
        GoalAmount = goalAmount;
    }
}