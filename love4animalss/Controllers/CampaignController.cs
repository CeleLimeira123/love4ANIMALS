using love4animalss.Interfaces;
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
}