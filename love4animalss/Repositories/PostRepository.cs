namespace love4animalss.Repositories;
using love4animalss.Interfaces;
using love4animalss.Models;

public class PostRepository : IPostRepository
{
    private static readonly List<Post> _posts = new();
    private static int _nextId = 1;

    public IEnumerable<Post> GetAll() => _posts;

    public Post? GetById(int id) => _posts.FirstOrDefault(p => p.Id == id);

    public void Add(Post post)
    {
        post.Id = _nextId++;
        post.CreatedAt = DateTime.UtcNow;
        _posts.Add(post);
        
    }

   public void Update(Post post)
    {
        var index = _posts.FindIndex(p => p.Id == post.Id);
        if (index != -1)
        {
            post.CreatedAt = _posts[index].CreatedAt; 
            _posts[index] = post;
        }
    }

    public void Delete(int id) 
    {
        var index = _posts.Find(p => p.Id == id);
        if (index !=null)
        {
            _posts.Remove(index);
        }
    }
}