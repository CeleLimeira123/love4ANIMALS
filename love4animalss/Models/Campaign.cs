namespace love4animalss.Models;

public class Campaign
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal GoalAmount { get; set; }
    public Campaign(int id, string title, string description, decimal goalAmount)
    {
        Id = id;
        Title = title;
        Description = description;
        GoalAmount = goalAmount;
    }
}