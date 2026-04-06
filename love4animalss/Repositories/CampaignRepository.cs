using love4animalss.Dtos;
using love4animalss.Interfaces;
using love4animalss.Models;

namespace love4animalss.Repositories;

public class CampaignRepository : ICampaignRepository
{
    
    private static readonly List<Campaign> _campaigns = new List<Campaign>
    {
        new Campaign(1, "Rescate de perritos", "Fondo para alimento", 500.00m),
        new Campaign(2, "Campaña de Vacunación", "Vacunas para refugios", 1000.00m)
    };

    public IEnumerable<GetCampaignDto> GetAll()
    {
        return _campaigns.Select(c => new GetCampaignDto(c.Id, c.Title, c.Description, c.GoalAmount));
    }
    public Campaign? GetById(int id)
    {
        return _campaigns.FirstOrDefault(c => c.Id == id);
    }

    public void Add(CreateCampaignDto campaignDto)
    {
        var newId = _campaigns.Any() ? _campaigns.Max(c => c.Id) + 1 : 1;
        var campaign = new Campaign(newId, campaignDto.Title, campaignDto.Description, campaignDto.GoalAmount);
        _campaigns.Add(campaign);
    }

    public void Update(int id, UpdateCampaignDto campaignDto)
    {
        var existing = _campaigns.FirstOrDefault(c => c.Id == id);
        if (existing != null)
        {
            existing.Title = campaignDto.Title;
            existing.Description = campaignDto.Description;
            existing.GoalAmount = campaignDto.GoalAmount;
        }
    }

    public void Delete(int id)
    {
        var campaign = _campaigns.FirstOrDefault(c => c.Id == id);
        if (campaign != null)
        {
            _campaigns.Remove(campaign);
        }
    }
}