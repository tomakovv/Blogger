﻿using Application.Dto;

namespace Application.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllPostsAsync(int pageNumber, int pageSize);
        Task<int> GetAllPostsCountAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        Task<PostDto> AddNewPostAsync(CreatePostDto newPost);
        Task<IEnumerable<PostDto>> GetPostByTitleAsync(string title);
        Task UpdatePostAsync(UpdatePostDto newPost);
        Task DeletePostAsync(int id);
    }
}
