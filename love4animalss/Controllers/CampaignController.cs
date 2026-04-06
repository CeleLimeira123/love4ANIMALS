using love4animalss.Interfaces;
using love4animalss.Models; 
using love4animalss.Dtos; 
using Microsoft.AspNetCore.Mvc;

namespace love4animalss.Controllers;

[ApiController]
[Route("v1/campaigns")]
public class CampaignController : ControllerBase
{
    private readonly ICampaignRepository _campaignRepository;

    public CampaignController(ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
    }

    [HttpGet]
    public IActionResult GetCampaigns()
    {
        var campaigns = _campaignRepository.GetAll();
        return Ok(campaigns);
    }

    [HttpPost]
    public IActionResult CreateCampaign([FromBody] CreateCampaignDto newCampaign)
    {
        if (newCampaign == null)
        {
            return BadRequest("Los datos de la campaña son requeridos.");
        }

        _campaignRepository.Add(newCampaign);
        return Ok(new { message = "Campaña creada con éxito", data = newCampaign });
    }

 [HttpPut("{id}")]
public IActionResult UpdateCampaign(int id, [FromBody] UpdateCampaignDto updatedCampaign)
{
    if (updatedCampaign == null)
    {
        return BadRequest("Datos de actualización no válidos.");
    }

    var existing = _campaignRepository.GetById(id);

    if (existing == null)
    {
        return NotFound(new { message = $"Error: La campaña con ID {id} no existe o ya fue eliminada." });
    }

    _campaignRepository.Update(id, updatedCampaign);
    
    return Ok(new { message = $"Campaña con ID {id} actualizada con éxito" });
}

    [HttpDelete("{id}")]
    public IActionResult DeleteCampaign(int id)
    {
        _campaignRepository.Delete(id);
        return Ok(new { message = $"Campaña {id} eliminada correctamente" });
    }
}