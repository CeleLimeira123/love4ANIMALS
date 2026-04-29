namespace love4animalss.Interfaces;
using love4animalss.Models;

public interface IDonationRepository
{
    Task<IEnumerable<Donation>> GetAllAsync();
    Task<Donation?> GetByIdAsync(int id);
    Task<IEnumerable<Donation>> GetByCampaignIdAsync(int campaignId);
    Task AddAsync(Donation donation);
    
    Task UpdateAsync(Donation donation);
    Task<bool> DeleteAsync(int id);

    Task<bool> SaveChangesAsync();
}