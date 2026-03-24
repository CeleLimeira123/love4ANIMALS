using love4animalss.Models;

namespace love4animalss.Interfaces;

public interface ICampaignRepository
{
    List<Campaign> GetAll();
}