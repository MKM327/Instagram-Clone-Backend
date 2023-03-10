using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access.UserDal;

public class UserDal : EFentityRepository<User, InstagramCloneContext>, IEFentityRepository<User>, IUserDal
{
    public async Task<List<User>> GetAllData()
    {
        using var context = new InstagramCloneContext();
        var list = await context.Users.Include(u => u.UserProfile)
            .ThenInclude(p => p.Comments)
            .Include(u => u.UserProfile)
            .ThenInclude(p => p.Posts)
            .Include(u => u.UserProfile)
            .ThenInclude(p => p.Comments)
            .ToListAsync();

        return list;
    }

    public async Task<User>? DeleteByIdAsync(int id)
    {
        using var context = new InstagramCloneContext();
        bool v = await DoesExitsAsync(id);
        if (v == false)
        {
            return null!;
        }

        var user = await context.Users.SingleOrDefaultAsync(user => user.Id == id);
        context.Entry(user).State = EntityState.Deleted;
        await context.SaveChangesAsync();
        return user;
    }
    public async Task<User> Update(User user, int id)
    {
        using var context = new InstagramCloneContext();
        bool doesExits = await DoesExitsAsync(id);
        if (doesExits == false)
            return null;
        user.Id = id;
        context.Entry(user).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return user;
    }
    public async Task<User> GetByIdAsync(int id)
    {
        using var context = new InstagramCloneContext();
        return await context.Users.Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Comments)
                                  .Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Posts)
                                  .Include(u => u.UserProfile)
                                  .ThenInclude(p => p.Comments)
                                  .SingleOrDefaultAsync(user => user.Id == id);

    }
}