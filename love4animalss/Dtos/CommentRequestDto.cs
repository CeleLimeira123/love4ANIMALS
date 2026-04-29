using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Representa la solicitud para crear o actualizar un comentario.
/// </summary>
public record CommentRequestDto(
    [Required(ErrorMessage = "El texto del comentario es obligatorio.")]
    [MinLength(3, ErrorMessage = "El comentario debe tener al menos 3 caracteres.")]
    [MaxLength(500, ErrorMessage = "El comentario no puede exceder los 500 caracteres.")]
    [Description("Contenido textual del comentario realizado por el usuario.")]
    string Text
);