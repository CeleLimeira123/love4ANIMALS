using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Información pública del usuario para perfiles y listados.
/// </summary>
public record GetUserDto (
    [Description("Identificador único del usuario.")]
    int Id,

    [Description("Nombre completo o alias del usuario.")]
    string Name,

    [Description("Dirección de correo electrónico registrada.")]
    string Email
);