using EDO.Models;
using EDO.Models.Inputs;
using EDO.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EDO.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EDOContext _context;

        public UserRepository(EDOContext context)
        {
            _context = context;
        }
        public async Task<bool> IsLoginUsed(string login)
        {
            return await _context.Users.AnyAsync(u => u.Login == login);
        }

        public async Task<bool> IsLoginUsedBeforeUpdate(string login)
        {
            var currentUser = await FindUserByLogin(login);
            return await _context.Users.AnyAsync(u => u.Login == login);
        }

        public async Task<Guid> CreateUser(UserRegistration userRegistration)
        {
            var newUser = new User(
                    userRegistration.FirstName,
                    userRegistration.SecondName,
                    userRegistration.ThirdName,
                    userRegistration.Login,
                    userRegistration.Password
            );
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser.Id;
        }

        public async Task UpdateUser(User user, UserRegistration userRegistration)
        {
            user.FirstName = userRegistration.FirstName;
            user.SecondName = userRegistration.SecondName;
            user.ThirdName = userRegistration.ThirdName;
            user.Login = userRegistration.Login;
            user.Password = userRegistration.Password;

            await _context.SaveChangesAsync();
        }

        public async Task<User> FindUserById(Guid userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user is null)
                throw new Exception("User not found");
            return user;
        }
        public async Task<User> FindUserByLogin(string login)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Login == login);
            if (user is null)
                throw new Exception("User not found");
            return user;
        }
    }
}
