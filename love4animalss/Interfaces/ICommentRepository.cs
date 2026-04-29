using love4animalss.Models;

namespace love4animalss.Interfaces;

public interface ICommentRepository
{
    IEnumerable<Comment> GetByPostId(int postId);
    Comment? GetById(int postId, int commentId);
    void Add(Comment comment);
    void Update(Comment comment);
    void Delete(int commentId);
}