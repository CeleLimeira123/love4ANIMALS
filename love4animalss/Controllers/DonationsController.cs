using Microsoft.AspNetCore.Mvc;
using love4animalss.Interfaces;
using love4animalss.Models;
using love4animalss.Dtos;
using Microsoft.AspNetCore.Authorization; 

namespace love4animalss.Controllers;

[ApiController]
[Route("v1/[controller]")]
[Tags("Gestión de Donaciones")]
[AllowAnonymous] 
public class DonationsController(
    IDonationRepository repository, 
    ICampaignRepository campaignRepository, 
    IUserRepository userRepository) : ControllerBase 
{
    [HttpGet]
    [EndpointSummary("Listado Global de Donaciones")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var donations = await repository.GetAllAsync();
        foreach (var donation in donations)
        {
            donation.Campaign = campaignRepository.GetById(donation.CampaignId)!;
            donation.User = userRepository.GetById(donation.UserId)!;
        }
        return Ok(donations);
    }

    [HttpGet("campaña/{campaignId}")]
    [EndpointSummary("Filtrar Donaciones por Campaña")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCampaign(int campaignId)
    {
        var campaign = campaignRepository.GetById(campaignId);
        if (campaign == null) return NotFound($"La campaña con ID {campaignId} no existe.");

        var donations = await repository.GetByCampaignIdAsync(campaignId);
        foreach (var d in donations)
        {
            d.Campaign = campaign;
            d.User = userRepository.GetById(d.UserId)!;
        }
        return Ok(donations);
    }

    [HttpPost]
    [EndpointSummary("Registrar Nueva Donación")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)] 
    [ProducesResponseType(StatusCodes.Status401Unauthorized)] 
    public async Task<IActionResult> Create([FromBody] CreateDonationDto dto)
    {
       if (!ModelState.IsValid) return BadRequest(ModelState);

        var campaign = campaignRepository.GetById(dto.CampaignId);
        var user = userRepository.GetById(dto.UserId);

        if (campaign == null) return BadRequest(new { mensaje = "La campaña especificada no existe." });
        if (user == null) return BadRequest(new { mensaje = "El usuario especificado no existe." });

        var newDonation = new Donation(dto.Amount, dto.CampaignId, dto.UserId, dto.Comment);
        
        await repository.AddAsync(newDonation);
        await repository.SaveChangesAsync();

        newDonation.Campaign = campaign;
        newDonation.User = user;

        return CreatedAtAction(nameof(GetAll), new { id = newDonation.Id }, newDonation); 
    }

    [HttpPut("{id}")]
    [EndpointSummary("Actualizar Datos de Donación")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] Donation donation)
    {
        if (id != donation.Id) return BadRequest("Los IDs no coinciden.");
        
        var existing = await repository.GetByIdAsync(id);
        if (existing == null) return NotFound("La donación no existe.");
        
        await repository.UpdateAsync(donation);
        await repository.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [EndpointSummary("Eliminar Registro de Donación")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await repository.DeleteAsync(id);
        if (!deleted) return NotFound("No se pudo encontrar la donación para eliminar.");
        
        await repository.SaveChangesAsync();
        return NoContent();
    }
}