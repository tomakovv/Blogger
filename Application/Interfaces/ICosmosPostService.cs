using Application.Dto.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICosmosPostService
    {
        Task<IEnumerable<CosmosPostDto>> GetAllPostsAsync();
        Task<CosmosPostDto> GetPostByIdAsync(string id);
        Task<CosmosPostDto> AddNewPostAsync(CreateCosmosPostDto newPost);
        Task<IEnumerable<CosmosPostDto>> GetPostByTitleAsync(string title);
        Task UpdatePostAsync(UpdateCosmosPostDto updatePost);
        Task DeletePostAsync(string id);
    }
}
