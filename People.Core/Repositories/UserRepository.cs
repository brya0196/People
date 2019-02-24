using People.Data;
using People.Data.Entities;
using People.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Core.Repositories
{
    public class UserRepository : IUser
    {
        private readonly PeopleDbContext _context;

        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task ChangePassword(int Id, string newPassword)
        {
            var user = GetById(Id);
            user.Password = newPassword;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var user = GetById(Id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int Id)
        {
            return _context.Users.Where(u => u.Id == Id).First();
        }

        public Task Update(User user)
        {
            var userFromDb = GetById(user.Id);
            userFromDb.IdRole = user.IdRole;
            userFromDb.Name = user.Name;
            userFromDb.Lastname = user.Lastname;
            userFromDb.Username = user.Username;

            return _context.SaveChangesAsync();
        }
    }
}
