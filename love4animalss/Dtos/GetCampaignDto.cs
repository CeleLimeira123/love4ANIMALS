namespace love4animalss.Dtos;

public record GetCampaignDto
(
    int Id, 
    string Title, 
    string Description, 
    decimal GoalAmount
);