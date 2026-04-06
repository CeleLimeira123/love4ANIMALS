using love4animalss.Dtos;
using love4animalss.Models; 

namespace love4animalss.Interfaces;

public interface ICampaignRepository
{ 
    IEnumerable<GetCampaignDto> GetAll(); 
    Campaign? GetById(int id); 
    void Add(CreateCampaignDto campaignDto);
    void Update(int id, UpdateCampaignDto campaignDto); 
    void Delete(int id);
}