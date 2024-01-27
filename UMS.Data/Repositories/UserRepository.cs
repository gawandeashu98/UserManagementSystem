using Microsoft.EntityFrameworkCore;
using UMS.Messages.Entities;
using UMS.Messages.Requests;
using USM.Data.DbContexts;

namespace USM.Data.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync(GetUsersRequest request);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> LoginUserAsyncAsync(LoginUserRequest request);
        Task<int> CreateUserAsync(User newUser);
        Task<int?> UpdateUserByIdAsync(User userToUpdate);
        Task<int?> DeleteUserByIdAsync(int userId);
    }

    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<List<User>> GetUsersAsync(GetUsersRequest request)
        {
            return await _userDbContext.User
                .Skip((request.PageDetails.PageNumber.Value - 1) * request.PageDetails.PageSize.Value)
                .Take(request.PageDetails.PageSize.Value)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _userDbContext.User.FindAsync(userId);
            if (user != null)
                return user;

            return null;
        }

        public async Task<User> LoginUserAsyncAsync(LoginUserRequest request)
        {
            var user = await _userDbContext.User.FirstOrDefaultAsync(u => u.UserName == request.UserName && u.Password == request.Password);
            if (user != null)
                return user;

            return null;
        }

        public async Task<int> CreateUserAsync(User newUser)
        {
            await _userDbContext.User.AddAsync(newUser);
            _userDbContext.SaveChanges();
            var user = _userDbContext.User.OrderBy(e => e.UserId).LastOrDefault(u => u.UserName == newUser.UserName && u.Password == newUser.Password);
            return user.UserId;
        }

        public async Task<int?> UpdateUserByIdAsync(User userToUpdate)
        {
            var user = await _userDbContext.User.FindAsync(userToUpdate.UserId);
            if (user != null)
            {
                _userDbContext.User.Update(userToUpdate);
                _userDbContext.SaveChanges();
                return userToUpdate.UserId;
            }
            return null;
        }

        public async Task<int?> DeleteUserByIdAsync(int userId)
        {
            var user = await _userDbContext.User.FindAsync(userId);
            if (user != null)
            {
                _userDbContext.User.Remove(user);
                _userDbContext.SaveChanges();
                return userId;
            }
            return null;
        }
    }
}
