using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Modelo para el registro de nuevos usuarios en la plataforma.
/// </summary>
public record CreateUserDto(
    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
    [MaxLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
    [Description("Nombre completo o alias del usuario.")]
    string Name, 

    [Required(ErrorMessage = "El correo electrónico es indispensable.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    [Description("Dirección de correo para notificaciones y acceso.")]
    string Email, 

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres por seguridad.")]
    [Description("Clave de acceso al sistema (se recomienda incluir números y símbolos).")]
    string Password
);