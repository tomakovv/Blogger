using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int PageSize);
        Task<int> GetAllCountAsync();
        Task<Post> GetByIdAsync(int id);
        Task<IEnumerable<Post>> GetByTitleAsync(string title);
        Task<Post> AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(Post post);
    }
}
