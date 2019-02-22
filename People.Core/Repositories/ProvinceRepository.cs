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
    public class ProvinceRepository : IProvince
    {
        private readonly PeopleDbContext _context;

        public ProvinceRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public async Task Add(Province province)
        {
            _context.Provinces.Add(province);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var province = GetById(Id);

            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Province> GetAll()
        {
            return _context.Provinces;
        }

        public Province GetById(int Id)
        {
            return _context.Provinces.Where(p => p.Id == Id).First();
        }

        public async Task Update(Province province)
        {
            var provinceFromDb = GetById(province.Id);
            provinceFromDb.Name = province.Name;
            await _context.SaveChangesAsync();
        }
    }
}
