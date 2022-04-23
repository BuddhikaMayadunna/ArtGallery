using ArtGalleryAPI.Models;
using ArtGalleryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<int>> Get()
        {
            var state = await postService.GetAsync();
            return Ok(state);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> Create(PostModel model)
        {
            var state = await postService.InsertAsync(model);
            return Ok(state);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<int>> Update(PostModel model)
        {
            var state = await postService.UpdateAsync(model);
            return Ok(state);
        }
    }
}
