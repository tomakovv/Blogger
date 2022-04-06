using Application.Dto;
using Application.Dto.Cosmos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers.V2
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ICosmosPostService _postService;
        public PostsController(ICosmosPostService postService)
        {
            _postService = postService;
        }
        [SwaggerOperation(Summary = "Retrives all posts")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(
                new
                {
                    Posts = posts,
                    Count = posts.Count()
                }); 
        }
        [SwaggerOperation(Summary = "Retrives a specific post by uniqe id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpGet("Search/{title}")]
        [SwaggerOperation(summary: "Search posts by Title")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var posts = await _postService.GetPostByTitleAsync(title);
            return Ok(posts);
        }
        [SwaggerOperation(Summary = "Create a new post")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCosmosPostDto newPost)
        {
            var post = await _postService.AddNewPostAsync(newPost);
            return Created($"api/posts/{post.Id}", post);
        }
        [SwaggerOperation(Summary = "Update a existing post")]
        [HttpPut]
        public async Task<ActionResult> Update(UpdateCosmosPostDto updatePost)
        {
            await _postService.UpdatePostAsync(updatePost);
            return NoContent();
        }
        [SwaggerOperation(Summary = "Delete post by id")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }
}
