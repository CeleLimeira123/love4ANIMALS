using love4animalss.Interfaces;
using love4animalss.Models;

namespace love4animalss.Repositories;

public class CampaignRepository : ICampaignRepository
{
    private List<Campaign> _campaigns;

    public CampaignRepository()
    {
        _campaigns = new List<Campaign>
        {
            new Campaign(1, "Rescate de perritos", "Fondo para alimento", 500.00m),
            new Campaign(2, "Campaña de Vacunación", "Vacunas para refugios", 1000.00m)
        };
    }

    public List<Campaign> GetAll() => _campaigns;
}