using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Modelo utilizado para actualizar la información de una campaña existente.
/// </summary>
public record UpdateCampaignDto(
    [Required(ErrorMessage = "El título es obligatorio para la actualización.")]
    [MinLength(5, ErrorMessage = "El título debe tener al menos 5 caracteres.")]
    [MaxLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres.")]
    [Description("Nuevo nombre de la campaña.")]
    string Title, 

    [Required(ErrorMessage = "La descripción no puede quedar vacía.")]
    [MaxLength(1000, ErrorMessage = "La descripción no puede exceder los 1000 caracteres.")]
    [Description("Nueva descripción detallada de la causa.")]
    string Description, 

    [Required]
    [Range(1, 1000000, ErrorMessage = "El monto meta debe ser un valor positivo entre 1 y 1,000,000 Bs.")]
    [Description("Nuevo monto objetivo de recaudación.")]
    decimal GoalAmount
);