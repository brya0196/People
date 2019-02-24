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
    public class ResidenceRepository : IResidence
    {
        private readonly PeopleDbContext _context;

        public ResidenceRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public async Task Add(Residence residence)
        {
            _context.Residences.Add(residence);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var residence = GetById(Id);
            _context.Residences.Remove(residence);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Residence> GetAll()
        {
            return _context.Residences;
        }

        public Residence GetById(int Id)
        {
            return _context.Residences.Where(r => r.Id == Id).First();
        }

        public async Task Update(Residence residence)
        {
            var residenceFromDb = GetById(residence.Id);

            residenceFromDb.IdCity = residence.IdCity;

            await _context.SaveChangesAsync();
        }
    }
}
