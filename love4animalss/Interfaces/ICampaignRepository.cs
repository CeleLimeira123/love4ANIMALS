using love4animalss.Models;
using love4animalss.Dtos; 
namespace love4animalss.Interfaces;

public interface ICampaignRepository
{ 
    
    IEnumerable<Campaign> GetAll(); 
    Campaign? GetById(int id); 
    void Add(Campaign campaign);     
    void Update(Campaign campaign);   
    void Delete(int id);
}