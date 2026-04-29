using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Modelo para el registro de una nueva donación destinada a una campaña específica.
/// </summary>
public record CreateDonationDto(
    [Required(ErrorMessage = "El monto de la donación es obligatorio.")]
    [Range(1, 50000, ErrorMessage = "El monto debe ser entre 1 y 50,000 Bs. por transacción.")]
    [Description("Monto de dinero a donar en bolivianos (Bs).")]
    decimal Amount,

    [Required(ErrorMessage = "Se debe especificar el ID de la campaña a la cual se apoya.")]
    [Description("Identificador único de la campaña beneficiaria.")]
    int CampaignId,

    [Required(ErrorMessage = "El ID del usuario donante es necesario para la trazabilidad.")]
    [Description("Identificador del usuario que realiza el aporte.")]
    int UserId,

    [MaxLength(200, ErrorMessage = "El comentario de aliento no puede superar los 200 caracteres.")]
    [Description("Mensaje opcional para los rescatistas (ej: '¡Mucha fuerza para el pequeño!').")]
    string? Comment // El '?' permite que sea opcional en el JSON
); // <--- ¡Este punto y coma es el que faltaba!