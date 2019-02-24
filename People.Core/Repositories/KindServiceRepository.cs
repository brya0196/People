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
    public class KindServiceRepository : IKindService
    {

        private readonly PeopleDbContext _context;

        public KindServiceRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public async Task Add(KindService kindService)
        {
            _context.kindServices.Add(kindService);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var kindService = GetById(Id);

            _context.kindServices.Remove(kindService);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<KindService> GetAll()
        {
            return _context.kindServices;
        }

        public KindService GetById(int Id)
        {
            return _context.kindServices.Where(ks => ks.Id == Id).First();
        }

        public async Task Update(KindService kindService)
        {
            var kindServicesFromDb = GetById(kindService.Id);
            kindServicesFromDb.Name = kindService.Name;
            await _context.SaveChangesAsync();
        }
    }
}
