using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Api.Models;
using Api.Services;
using System.Numerics;
using Microsoft.AspNetCore.Http.HttpResults;
using Api.ServiceUtils;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // base route: /api/example
    public class PostsController : ControllerBase
    {
        private readonly PostsService _postsService;
        public PostsController(PostsService postsService)
        {
            _postsService = postsService;
        }


        [HttpGet]
        public async Task<IActionResult> GetPosts(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "createdat",
            [FromQuery] string sortOrder = "desc",
            [FromQuery] int? userId = null,
            [FromQuery] string? search = null
        )
        {
            var (returnCode,posts) = await _postsService.GetPosts(
                page, pageSize,
                sortBy, sortOrder,
                userId,
                search
            );
            var result = ServiceHelper.HandleReturnCode(returnCode);
            if (result is not OkResult) { return result; }
            return Ok(posts);
        }

        [HttpPut("create")]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDTO post)
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdStr == null)
            {
                return Unauthorized();
            }
            int userId = int.Parse(userIdStr);

            var (returnCode,createdPost) = await _postsService.CreatePost(userId, post.Content);
            var result = ServiceHelper.HandleReturnCode(returnCode);
            if (result is not OkResult) { return result; }
            return Ok(createdPost);
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> DeletePost([FromBody] DeletePostDTO post)
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdStr == null)
            {
                return Unauthorized();
            }
            int userId = int.Parse(userIdStr);

            var (returnCode, deletedPost) = await _postsService.DeletePost(userId, post);
            var result = ServiceHelper.HandleReturnCode(returnCode);
            if (result is not OkResult) { return result; }
            return Ok(deletedPost);
        }

        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDTO post)
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdStr == null)
            {
                return Unauthorized();
            }
            int userId = int.Parse(userIdStr);

            var (returnCode, updatedPost) = await _postsService.UpdatePost(userId, post);
            var result = ServiceHelper.HandleReturnCode(returnCode);
            if (result is not OkResult) { return result; }
            return Ok(updatedPost);
        }
    }
}
