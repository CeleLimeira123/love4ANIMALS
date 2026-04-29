using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Modelo para el registro de una nueva campaña de recaudación o ayuda.
/// </summary>
public record CreateCampaignDto(
    [Required(ErrorMessage = "El título es obligatorio para identificar la campaña.")]
    [MinLength(5, ErrorMessage = "El título es demasiado corto (mínimo 5 caracteres).")]
    [MaxLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres.")]
    [Description("Nombre público de la campaña (ej: Ayuda para 'Firulais').")]
    string Title, 

    [Required(ErrorMessage = "Debes proporcionar una descripción detallada.")]
    [MaxLength(1000, ErrorMessage = "La descripción es muy larga (máximo 1000 caracteres).")]
    [Description("Explicación de la causa, objetivos y cómo se usará el dinero.")]
    string Description, 

    [Required]
    [Range(1, 1000000, ErrorMessage = "El monto meta debe estar entre 1 y 1,000,000 Bs.")]
    [Description("Monto objetivo de recaudación en bolivianos.")]
    decimal GoalAmount
);