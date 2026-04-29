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
        if (post.CreatedAt == default) 
        {
            post.CreatedAt = DateTime.UtcNow;
        }
        _posts.Add(post);
    }

    public void Update(Post post)
    {
        var existingPost = _posts.FirstOrDefault(p => p.Id == post.Id);
        if (existingPost != null)
        {
            
            post.CreatedAt = existingPost.CreatedAt;
            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.ImageUrl = post.ImageUrl; 
            existingPost.CampaignId = post.CampaignId;
        }
    }

    public void Delete(int id) 
    {
        var postToRemove = _posts.FirstOrDefault(p => p.Id == id);
        if (postToRemove != null)
        {
            _posts.Remove(postToRemove);
        }
    }
}