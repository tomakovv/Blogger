using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postrepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postrepository = postRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PostDto>> GetAllPostsAsync(int pageNumber, int pageSize)
        {
            var posts = await _postrepository.GetAllAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await _postrepository.GetByIdAsync(id);
            return _mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> AddNewPostAsync(CreatePostDto newPost)
        {
            if (string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Post cannot have empty title");
            }

            var post = _mapper.Map<Post>(newPost);
            var result = await _postrepository.AddAsync(post);
            return _mapper.Map<PostDto>(result);
        }
        public async Task UpdatePostAsync(UpdatePostDto updatePost)
        {
            var existingPost = await _postrepository.GetByIdAsync(updatePost.Id);
            var post = _mapper.Map(updatePost, existingPost);
            await _postrepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _postrepository.GetByIdAsync(id);
            await _postrepository.DeleteAsync(post);
        }

        public async Task<IEnumerable<PostDto>> GetPostByTitleAsync(string title)
        {
            var posts = await _postrepository.GetByTitleAsync(title);
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public async Task<int> GetAllPostsCountAsync()
        {
            return await _postrepository.GetAllCountAsync();
        }
    }
}
