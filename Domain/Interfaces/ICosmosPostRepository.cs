﻿using Domain.Entities.Cosmos;
namespace Domain.Interfaces
{
    public interface ICosmosPostRepository
    {
        Task<IEnumerable<CosmosPost>> GetAllAsync();
        Task<CosmosPost> GetByIdAsync(string id);
        Task<IEnumerable<CosmosPost>> GetByTitleAsync(string title);
        Task<CosmosPost> AddAsync(CosmosPost post);
        Task UpdateAsync(CosmosPost post);
        Task DeleteAsync(CosmosPost post);
    }
}
