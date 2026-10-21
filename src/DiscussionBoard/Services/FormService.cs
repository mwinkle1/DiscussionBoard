using DiscussionBoard.Data;
using DiscussionBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscussionBoard.Services;

public class ForumService(ApplicationDbContext db)
{
    public async Task<List<Forum>> GetAllAsync()
    {
        return await db.Forums
            .Where(f => !f.IsDeleted)
            .ToListAsync();
    }
}
