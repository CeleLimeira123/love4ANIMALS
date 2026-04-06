namespace love4animalss.Dtos;

public record UpdateCampaignDto(
    string Title, 
    string Description, 
    decimal GoalAmount
);