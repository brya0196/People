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
    public class ServiceRepository : IService
    {
        private readonly PeopleDbContext _context;

        public ServiceRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public async Task Add(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var service = GetById(Id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services;
        }

        public Service GetById(int Id)
        {
            return _context.Services.Where(s => s.Id == Id).First();
        }

        public async Task Update(Service service)
        {
            var serviceFromDb = GetById(service.Id);
            serviceFromDb.IdKindService = service.IdKindService;
            serviceFromDb.Payment = service.Payment;
            await _context.SaveChangesAsync();
        }
    }
}
