namespace love4animalss.Interfaces;
using love4animalss.Models;

public interface IPostRepository
{
    IEnumerable<Post> GetAll();
    Post? GetById(int id);
    void Add(Post post);
    void Update(Post post);
    void Delete(int id);
}