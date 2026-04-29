using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Modelo utilizado para actualizar el contenido de una publicación existente.
/// </summary>
public record UpdatePostDto(
    [Required(ErrorMessage = "El título es obligatorio para actualizar el post.")]
    [MaxLength(150, ErrorMessage = "El título no puede superar los 150 caracteres.")]
    [Description("Nuevo título de la publicación.")]
    string Title, 

    [Required(ErrorMessage = "El contenido no puede quedar vacío.")]
    [MinLength(10, ErrorMessage = "El contenido debe tener al menos 10 caracteres.")]
    [Description("Nuevo cuerpo o mensaje del post.")]
    string Content,

    [Required(ErrorMessage = "La URL de la imagen es obligatoria.")]
    [Url(ErrorMessage = "Debe ser una dirección URL válida.")]
    [Description("Nueva URL de la imagen (o la misma si no cambió).")]
    string ImageUrl, 

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "La campaña asociada debe ser válida.")]
    [Description("ID de la campaña a la que pertenece este post.")]
    int CampaignId   
);