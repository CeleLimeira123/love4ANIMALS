using love4animalss.Interfaces;
using love4animalss.Models;

namespace love4animalss.Repositories;

public class CampaignRepository : ICampaignRepository
{
    private static readonly List<Campaign> _campaigns = new()
    {
        new Campaign { Id = 1, Title = "Rescate Cochabamba", Description = "Ayuda para refugios", GoalAmount = 5000 },
        new Campaign { Id = 2, Title = "Campaña de Vacunación", Description = "Vacunas para perros callejeros", GoalAmount = 2000 }
    };

    public IEnumerable<Campaign> GetAll() => _campaigns;

    public Campaign? GetById(int id) => _campaigns.FirstOrDefault(c => c.Id == id);

    public void Add(Campaign campaign)
    {
        campaign.Id = _campaigns.Any() ? _campaigns.Max(c => c.Id) + 1 : 1;
        _campaigns.Add(campaign);
    }

    public void Update(Campaign campaign)
    {
        var existing = GetById(campaign.Id);
        if (existing != null)
        {
            existing.Title = campaign.Title;
            existing.Description = campaign.Description;
            existing.GoalAmount = campaign.GoalAmount;
        }
    }

    public void Delete(int id)
    {
        var campaign = GetById(id);
        if (campaign != null)
        {
            DonationRepository.RemoveAllByCampaignId(id);

            _campaigns.Remove(campaign);
        }
    }
}