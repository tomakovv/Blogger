using Application.Dto;

namespace Application.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllPostsAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        Task<PostDto> AddNewPostAsync(CreatePostDto newPost);
        Task<IEnumerable<PostDto>> GetPostByTitleAsync(string title);
        Task UpdatePostAsync(UpdatePostDto newPost);
        Task DeletePostAsync(int id);
    }
}
