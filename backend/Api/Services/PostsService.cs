using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel;
using System.Linq.Dynamic.Core;
using System.Reflection;
using Api.ServiceUtils;

/*
TODO:
ESSENTIALS: GetAll (maybe not ALL) posts, GetAPost, GetPostsByUser, CreatePost, UpdatePost, DeletePost 
EXTRA: ReactToPost, GetPostReactions, GetRepliesToAPost, CreateReplyToAPost, UpdateReplyToAPost, DeleteReplyToAPost
*/
namespace Api.Services
{
    public class PostsService
    {
        private readonly TVDbContext _context;

        public PostsService(TVDbContext context)
        {
            _context = context;
        }
        public async Task<(ServiceReturnCode, PostQueryDTO?)> GetPosts(
            int page,
            int pageSize,
            string sortBy,
            string sortOrder,
            int? userId,
            string? search
        )
        {
            if (page <= 0 || pageSize <= 0) { return (ServiceReturnCode.InvalidInput, null); }
            var sortProperty = typeof(Post).GetProperty(sortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance); 
            if (sortProperty == null) { return (ServiceReturnCode.InvalidInput, null); }

            var query = _context.Posts.AsQueryable();
            if (userId.HasValue)
            {
                query = query.Where(p => p.UserId == userId);
            }
            if (search != null)
            {
                query = query.Where(p => p.Content.Contains(search));
            }
            query = sortOrder.ToLower() == "asc"
                ? query.OrderBy(sortBy)
                : query.OrderBy(sortBy + " descending");
            query = query
                .Where(p => !p.IsDeleted)
                .Where(p => !p.IsOfficial);
            var totalItems = await query.CountAsync();
            var posts = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.Author)
                .ToListAsync();
            return (ServiceReturnCode.Success, new PostQueryDTO
            {
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                Posts = posts.Select(p => new PostDTO
                {
                    Id = p.Id,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Author = p!.Author!.Username,
                    Reactions = p.Reactions
                }).ToList()
            });
        }
        public async Task<(ServiceReturnCode, CreatePostDTO?)> CreatePost(int userId, string content)
        {
            if (String.IsNullOrEmpty(content)) { return (ServiceReturnCode.InvalidInput,null); }
            var post = new Post
            {
                UserId = userId,
                Content = content,
                CreatedAt = DateTime.UtcNow,
            };
            var createdPost = await _context.AddAsync(post);
            if (createdPost == null) { return (ServiceReturnCode.InternalError,null); }
            await _context.SaveChangesAsync();
            return (ServiceReturnCode.Success,new CreatePostDTO
            {
                Id = post.Id,
                Content = post.Content,
            });
        }
        public async Task<(ServiceReturnCode, DeletePostDTO?)> DeletePost(int userId, DeletePostDTO post)
        {
            var postToDelete = await _context
                .Posts
                .FirstOrDefaultAsync(p => p.Id == post.Id);
            if (postToDelete == null) { return (ServiceReturnCode.NotFound, null); }
            if (postToDelete.UserId != userId) { return (ServiceReturnCode.Unauthorized, null); }
            if (postToDelete.IsDeleted) { return (ServiceReturnCode.NotFound, null); }
            postToDelete.IsDeleted = true;
            await _context.SaveChangesAsync();
            return (ServiceReturnCode.Success, new DeletePostDTO
            {
                Id = postToDelete.Id
            });
        }

        public async Task<(ServiceReturnCode, UpdatePostDTO?)> UpdatePost(int userId, UpdatePostDTO post)
        {
            var postToUpdate = await _context
                .Posts
                .FirstOrDefaultAsync(p => p.Id == post.Id);
            if (postToUpdate == null) { return (ServiceReturnCode.NotFound, null); }
            if (postToUpdate.UserId != userId) { return (ServiceReturnCode.Unauthorized, null); }
            if (postToUpdate.IsDeleted) { return (ServiceReturnCode.NotFound, null); }
            postToUpdate.UpdatedAt = DateTime.UtcNow;
            postToUpdate.Content = post.NewContent;
            await _context.SaveChangesAsync();
            return (ServiceReturnCode.Success, new UpdatePostDTO
            {
                Id = postToUpdate.Id,
                NewContent = postToUpdate.Content
            });
        }
    }
}
