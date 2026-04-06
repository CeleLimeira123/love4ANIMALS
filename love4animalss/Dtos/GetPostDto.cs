namespace love4animalss.Dtos;

public record GetPostDto(
    int Id, 
    string Title, 
    string Content, 
    int CampaignId,
    DateTime CreatedAt
);