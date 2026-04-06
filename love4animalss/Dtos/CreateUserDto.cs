namespace love4animalss.Dtos;

public record CreateUserDto(
    string Name, 
    string Email, 
    string Password
);