namespace love4animalss.Dtos;

public record CreateCampaignDto(
    string Title, 
    string Description, 
    decimal GoalAmount
);