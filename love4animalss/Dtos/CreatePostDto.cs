using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Modelo para crear una nueva publicación asociada a una campaña.
/// </summary>
public record CreatePostDto(
    [Required(ErrorMessage = "El título del post es obligatorio.")]
    [MaxLength(150, ErrorMessage = "El título no puede superar los 150 caracteres.")]
    [Description("Título llamativo para la publicación (ej: ¡Final feliz para Luna!).")]
    string Title, 

    [Required(ErrorMessage = "El contenido del post no puede estar vacío.")]
    [MinLength(10, ErrorMessage = "El contenido debe ser más descriptivo (mínimo 10 caracteres).")]
    [Description("Cuerpo del mensaje o historia que se desea compartir.")]
    string Content, 

    [Required(ErrorMessage = "La URL de la imagen es obligatoria.")]
    [Url(ErrorMessage = "Debes proporcionar una dirección URL válida para la imagen.")]
    [Description("Enlace a la fotografía o recurso visual del post.")]
    string ImageUrl, 

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Debes asociar el post a una campaña válida.")]
    [Description("ID de la campaña a la que pertenece esta actualización.")]
    int CampaignId   
);