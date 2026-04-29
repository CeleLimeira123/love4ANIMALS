using love4animalss.Interfaces;
using love4animalss.Models; 
using love4animalss.Dtos; 
using Microsoft.AspNetCore.Mvc;

namespace love4animalss.Controllers;

[ApiController]
[Route("v1/campaigns")]
[Tags("Gestión de Campañas")]
public class CampaignController : ControllerBase
{
    private readonly ICampaignRepository _campaignRepository;

    public CampaignController(ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
    }

    /// <summary>
    /// Obtiene el listado completo de todas las campañas.
    /// </summary>
    [HttpGet]
    [EndpointSummary("Listar campañas")]
    [ProducesResponseType<IEnumerable<Campaign>>(200)] 
    public IActionResult GetCampaigns()
    {
        var campaigns = _campaignRepository.GetAll();
        return Ok(campaigns);
    }

    /// <summary>
    /// Crea una nueva campaña convirtiendo el DTO al Modelo.
    /// </summary>
    [HttpPost]
    [EndpointSummary("Registrar nueva campaña")]
    [ProducesResponseType(201)] 
    [ProducesResponseType(400)]
    public IActionResult CreateCampaign([FromBody] CreateCampaignDto newCampaignDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var campaign = new Campaign
        {
            Title = newCampaignDto.Title,
            Description = newCampaignDto.Description,
            GoalAmount = newCampaignDto.GoalAmount
        };

        _campaignRepository.Add(campaign);
        
        return CreatedAtAction(nameof(GetCampaigns), new { id = campaign.Id }, campaign);
    }

    /// <summary>
    /// Actualiza una campaña existente.
    /// </summary>
    [HttpPut("{id}")]
    [EndpointSummary("Actualizar campaña")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCampaign(int id, [FromBody] UpdateCampaignDto updatedDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existing = _campaignRepository.GetById(id);
        if (existing == null)
        {
            return NotFound(new { message = $"Error: La campaña con ID {id} no existe." });
        }

        
        existing.Title = updatedDto.Title;
        existing.Description = updatedDto.Description;
        existing.GoalAmount = updatedDto.GoalAmount;

        _campaignRepository.Update(existing);
        
        return Ok(new { message = $"Campaña con ID {id} actualizada con éxito" });
    }

    /// <summary>
    /// Elimina una campaña mediante su ID.
    /// </summary>
    [HttpDelete("{id}")]
    [EndpointSummary("Eliminar campaña")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult DeleteCampaign(int id)
    {
        var existing = _campaignRepository.GetById(id);
        if (existing == null) return NotFound();

        _campaignRepository.Delete(id);
        return Ok(new { message = $"Campaña {id} eliminada correctamente" });
    }
}