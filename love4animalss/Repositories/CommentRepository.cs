using love4animalss.Interfaces;
using love4animalss.Models;

namespace love4animalss.Repositories;

public class CommentRepository : ICommentRepository
{
    private static readonly List<Comment> _comments = new();
    private static int _nextId = 1;

    public IEnumerable<Comment> GetByPostId(int postId) => 
        _comments.Where(c => c.PostId == postId);

    public Comment? GetById(int postId, int commentId) => 
        _comments.FirstOrDefault(c => c.Id == commentId && c.PostId == postId);

    public void Add(Comment comment)
    {
        comment.Id = _nextId++;
        comment.CreatedAt = DateTime.UtcNow;
        _comments.Add(comment);
    }

    public void Update(Comment comment)
    {
        var existing = _comments.FirstOrDefault(c => c.Id == comment.Id);
        if (existing != null)
        {
            existing.Text = comment.Text;
        }
    }

    public void Delete(int commentId) => 
        _comments.RemoveAll(c => c.Id == commentId);
}