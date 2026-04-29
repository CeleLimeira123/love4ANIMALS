using System.ComponentModel.DataAnnotations;

namespace love4animalss.Models;

/// <summary>
/// Representa a un usuario registrado en la plataforma Love4Animals.
/// </summary>
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress] 
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

}