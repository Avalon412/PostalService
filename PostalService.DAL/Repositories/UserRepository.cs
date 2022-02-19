using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostalService.DAL.Contracts;
using PostalService.DAL.Models;

namespace PostalService.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostalDbContext _dbContext;

        public UserRepository(PostalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserModel> Create(UserModel user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserModel>> Get()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> Get(int id)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task Remove(UserModel user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UserModel user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
