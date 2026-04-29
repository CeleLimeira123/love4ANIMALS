namespace love4animalss.Dtos;

// REGLA: El nombre aquí debe ser EXACTAMENTE CommentDto
public record CommentDto(
    int Id, 
    string Text, 
    int PostId, 
    DateTime CreatedAt
);