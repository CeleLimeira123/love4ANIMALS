namespace love4animalss.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CampaignId { get; set; } 
    public DateTime CreatedAt { get; set; }
}