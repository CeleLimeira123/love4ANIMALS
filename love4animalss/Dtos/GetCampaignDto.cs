using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Información detallada de una campaña para ser visualizada en el sistema.
/// </summary>
public record GetCampaignDto(
    [Description("Identificador único de la campaña.")]
    int Id, 

    [Description("Título o nombre de la campaña.")]
    string Title, 

    [Description("Descripción completa de la causa y objetivos.")]
    string Description, 

    [Description("Monto total que se busca recaudar (en bolivianos).")]
    decimal GoalAmount
);