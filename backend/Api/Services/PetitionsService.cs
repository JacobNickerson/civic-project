using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel;
using System.Linq.Dynamic.Core;
using System.Reflection;
using Api.ServiceUtils;
using Npgsql;

/*
TODO:
ESSENTIALS: GetAll (maybe not ALL) posts, GetAPost, GetPostsByUser, CreatePost, UpdatePost, DeletePost 
EXTRA: ReactToPost, GetPostReactions, GetRepliesToAPost, CreateReplyToAPost, UpdateReplyToAPost, DeleteReplyToAPost
*/
namespace Api.Services
{
    public class PetitionsService
    {
        private readonly TVDbContext _context;

        public PetitionsService(TVDbContext context)
        {
            _context = context;
        }
        public async Task<(ServiceReturnCode, PostQueryDTO?)> GetPetitionsAsync(
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

            var query = _context.Petitions.AsQueryable();
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
                .Where(p => !p.IsOfficial)
                .Where(p => p.ParentId == null);
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
        public async Task<(ServiceReturnCode, CreatePetitionDTO?)> CreatePetitionAsync(int userId, string content)
        {
            if (String.IsNullOrEmpty(content)) { return (ServiceReturnCode.InvalidInput,null); }
            var petition = new Petition
            {
                UserId = userId,
                Content = content
            }; 
            var createdPetition = await _context.AddAsync(petition);
            if (createdPetition == null) { return (ServiceReturnCode.InternalError,null); }
            await _context.SaveChangesAsync();
            return (ServiceReturnCode.Success,new CreatePetitionDTO
            {
                Id = petition.Id,
                Content = petition.Content,
            });
        }
        public async Task<(ServiceReturnCode, DeletePetitionDTO?)> DeletePetitionAsync(int userId, int petitionId)
        {
            var petitionToDelete = await _context
                .Petitions
                .FirstOrDefaultAsync(p => p.Id == petitionId);
            if (petitionToDelete == null) { return (ServiceReturnCode.NotFound, null); }
            if (petitionToDelete.UserId != userId) { return (ServiceReturnCode.Unauthorized, null); }
            if (petitionToDelete.IsDeleted) { return (ServiceReturnCode.NotFound, null); }
            petitionToDelete.Status = PetitionStatus.Failed;
            // TODO: Should deleted petitions be marked as deleted or kept visible but set as failed?
            //       Waiting to hear back from the team. 
            // petitionToDelete.IsDeleted = true;
            petitionToDelete.UpdatedAt = DateTime.UtcNow;
            // if (petitionToDelete.ParentId == null) // top level post, delete children
            // {
            //     await RecursivelyDeleteReplies(petitionToDelete.Id);
            // }
            await _context.SaveChangesAsync();
            return (ServiceReturnCode.Success, new DeletePetitionDTO
            {
                Id = petitionToDelete.Id
            });
        }

        public async Task<(ServiceReturnCode, CreatePostDTO?)> CreateReplyAsync(int userId, int parentId, string content)
        {
            if (String.IsNullOrEmpty(content)) { return (ServiceReturnCode.InvalidInput,null); }
            var parent = await _context.Petitions.FirstOrDefaultAsync(p => p.Id == parentId);
            if (parent == null || parent.IsDeleted)
            {
                return (ServiceReturnCode.NotFound, null);
            }
            var reply = new Post
            {
                UserId = userId,
                ParentId = parentId, 
                Content = content,
                CreatedAt = DateTime.UtcNow,
                ParentPost = parent
            };
            var createdReply = await _context.AddAsync(reply);
            if (createdReply == null) { return (ServiceReturnCode.InternalError,null); }
            await _context.SaveChangesAsync();
            return (ServiceReturnCode.Success, new CreatePostDTO
            {
                Id = reply.Id,
                Content = reply.Content
            });
        }
        public async Task<(ServiceReturnCode, List<PostDTO>)> GetRepliesAsync(int parentId)
        {
            var replies = await _context.Posts
                .Where(p => p.ParentId == parentId)
                .Select(p => new PostDTO
                {
                    Id = p.Id,
                    Content = p.IsDeleted ? null : p.Content,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Author = p!.Author!.Username,
                    Reactions = p.Reactions
                }).ToListAsync();
            return (ServiceReturnCode.Success, replies);
        } 
        // Helpers
        private async Task<bool> RecursivelyDeleteReplies(int parentId)
        {
            await _context.Posts
            .Where(p => p.ParentId == parentId)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.IsDeleted, true)
                .SetProperty(p => p.UpdatedAt, DateTime.UtcNow)
            );

            var childIds = await _context.Posts
                .Where(p => p.ParentId == parentId)
                .Select(p => p.Id)
                .ToListAsync();
            foreach (var childId in childIds)
            {
                await RecursivelyDeleteReplies(childId);
            }
            return true;
        }
    }
}
