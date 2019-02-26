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
    public class CityRepository : ICity
    {
        private readonly PeopleDbContext _context;

        public CityRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public async Task Add(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var city = GetById(Id);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<City> GetAll()
        {
            return _context.Cities;
        }

        public City GetById(int Id)
        {
            return _context.Cities.Where(c => c.Id == Id).First();
        }

        public IEnumerable<City> GetByIdProvince(int Id)
        {
            return _context.Cities.Where(c => c.IdProvince == Id);
        }

        public async Task Update(City city)
        {
            var cityFromdB = GetById(city.Id);
            cityFromdB.Name = city.Name;
            cityFromdB.IdProvince = city.IdProvince;
            await _context.SaveChangesAsync();
        }
    }
}
