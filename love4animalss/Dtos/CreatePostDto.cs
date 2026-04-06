namespace love4animalss.Dtos;

public record CreatePostDto(
    string Title, 
    string Content, 
    int CampaignId
);