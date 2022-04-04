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
        public IEnumerable<PostDto> GetAllPosts()
        {
            var posts = _postrepository.GetAll();
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }

        public PostDto GetPostById(int id)
        {
            var post = _postrepository.GetById(id);
            return _mapper.Map<PostDto>(post);
        }

        public PostDto AddNewPost(CreatePostDto newPost)
        {
            if (string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Post cannot have empty title");
            }

            var post = _mapper.Map<Post>(newPost);
            _postrepository.Add(post);
            return _mapper.Map<PostDto>(post);
        }
        public void UpdatePost(UpdatePostDto updatePost)
        {
            var existingPost = _postrepository.GetById(updatePost.Id);
            var post = _mapper.Map(updatePost, existingPost);
            _postrepository.Update(post);
        }

        public void DeletePost(int id)
        {
            var post = _postrepository.GetById(id);
            _postrepository.Delete(post);
        }

        public IEnumerable<PostDto> GetPostByTitle(string title)
        {
            var posts = _postrepository.GetByTitle(title);
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }
    }
}
