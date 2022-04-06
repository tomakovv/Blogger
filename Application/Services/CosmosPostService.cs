﻿using Application.Dto.Cosmos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities.Cosmos;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CosmosPostService : ICosmosPostService
    {
        private static ICosmosPostRepository _postRepository;
        private static IMapper _mapper;

        public CosmosPostService(ICosmosPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;

        }

        public async Task<IEnumerable<CosmosPostDto>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CosmosPostDto>>(posts);
        }

        public async Task<CosmosPostDto> GetPostByIdAsync(string id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            return _mapper.Map<CosmosPostDto>(post);
        }

        public async Task<IEnumerable<CosmosPostDto>> GetPostByTitleAsync(string title)
        {
            var posts = await _postRepository.GetByTitleAsync(title);
            return _mapper.Map<IEnumerable<CosmosPostDto>>(posts);
        }

        public async Task UpdatePostAsync(UpdateCosmosPostDto updatePost)
        {
            var existingPost = await _postRepository.GetByIdAsync(updatePost.Id);
            var post = _mapper.Map(updatePost, existingPost);
            await _postRepository.UpdateAsync(post);


        }
        public async Task<CosmosPostDto> AddNewPostAsync(CreateCosmosPostDto newPost)
        {
            if (string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Post cannot have empty title.");
            }
            var post = _mapper.Map<CosmosPost>(newPost);
             var result = await _postRepository.AddAsync(post);
            return _mapper.Map<CosmosPostDto>(result);

        }

        public async Task DeletePostAsync(string id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            await _postRepository.DeleteAsync(post);
        }
    }
}
