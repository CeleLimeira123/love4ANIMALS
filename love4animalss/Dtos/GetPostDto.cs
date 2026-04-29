using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Modelo detallado de una publicación para ser mostrado en la interfaz.
/// </summary>
public record GetPostDto(
    [Description("Identificador único de la publicación.")]
    int Id, 

    [Description("Título de la publicación.")]
    string Title, 

    [Description("Contenido completo o cuerpo del post.")]
    string Content, 

    [Description("URL de la imagen asociada al post.")]
    string ImageUrl, 

    [Description("ID de la campaña a la que pertenece esta publicación.")]
    int CampaignId,

    [Description("Fecha y hora en la que se creó el post (Formato UTC).")]
    DateTime CreatedAt
);