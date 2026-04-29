using love4animalss.Interfaces;
using love4animalss.Models;

namespace love4animalss.Repositories;

public class DonationRepository : IDonationRepository
{
    private static readonly List<Donation> _donations = new();
    private static int _nextId = 1;

        public static void RemoveAllByCampaignId(int campaignId)
    {
        _donations.RemoveAll(d => d.CampaignId == campaignId);
    }

    public async Task<IEnumerable<Donation>> GetAllAsync() => 
        await Task.FromResult(_donations);

    public async Task<Donation?> GetByIdAsync(int id) => 
        await Task.FromResult(_donations.FirstOrDefault(d => d.Id == id));

    public async Task<IEnumerable<Donation>> GetByCampaignIdAsync(int campaignId) => 
        await Task.FromResult(_donations.Where(d => d.CampaignId == campaignId));

    public async Task AddAsync(Donation donation)
    {
        donation.Id = _nextId++;
        donation.DonationDate = DateTime.UtcNow;
        _donations.Add(donation);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Donation donation)
    {
        var existing = _donations.FirstOrDefault(d => d.Id == donation.Id);
        if (existing != null)
        {
            existing.Amount = donation.Amount;
            existing.Comment = donation.Comment;
            existing.CampaignId = donation.CampaignId;
            existing.UserId = donation.UserId;
        }
        await Task.CompletedTask;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var removedCount = _donations.RemoveAll(d => d.Id == id);
        return await Task.FromResult(removedCount > 0);
    }

    public async Task<bool> SaveChangesAsync() => await Task.FromResult(true);
}