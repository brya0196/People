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
    public class RoleRepository : IRoles
    {
        private readonly PeopleDbContext _context;

        public RoleRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public async Task Add(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var role = GetById(Id);
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles;
        }

        public Role GetById(int Id)
        {
            return _context.Roles.Where(r => r.Id == Id).First();
        }

        public async Task Update(Role role)
        {
            var roleFromDb = GetById(role.Id);
            roleFromDb.Name = role.Name;
            await _context.SaveChangesAsync();
        }
    }
}
