using Cosmonaut;
using Cosmonaut.Extensions;
using Domain.Entities.Cosmos;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class CosmosPostRepository : ICosmosPostRepository
    {
        private readonly ICosmosStore<CosmosPost> _cosmosStore;
        public CosmosPostRepository(ICosmosStore<CosmosPost> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }


        public async Task<IEnumerable<CosmosPost>> GetAllAsync()
        {
            var posts = await _cosmosStore.Query().ToListAsync();
            return posts;
        }
        public async Task<CosmosPost> GetByIdAsync(string id)
        {
            var post = await _cosmosStore.FindAsync(id);
            return post;
        }

        public async Task<IEnumerable<CosmosPost>> GetByTitleAsync(string title)
        {
            var posts = await _cosmosStore.Query().Where(x => x.Title.ToUpper().Contains(title.ToUpper())).ToListAsync();
            return posts;
        }
        public async Task<CosmosPost> AddAsync(CosmosPost post)
        {
            post.Id = Guid.NewGuid().ToString();
            return await _cosmosStore.AddAsync(post);
        }

        public async Task UpdateAsync(CosmosPost post)
        {
            await _cosmosStore.UpdateAsync(post);
        }

        public async Task DeleteAsync(CosmosPost post)
        {
            await _cosmosStore.RemoveAsync(post);
        }
    }
}
