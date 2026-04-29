using System.ComponentModel;

namespace love4animalss.Dtos;

/// <summary>
/// Representación de la información de una donación registrada en el sistema.
/// </summary>
public record GetDonationDto(
    [Description("Identificador único de la transacción.")]
    int Id,

    [Description("Monto recaudado en esta transacción.")]
    decimal Amount,

    [Description("Fecha y hora exacta en la que se confirmó la donación.")]
    DateTime DonationDate,

    [Description("ID de la campaña asociada.")]
    int CampaignId,

    [Description("Nombre del donante (para visualización en el muro de aportes).")]
    string DonorName
);