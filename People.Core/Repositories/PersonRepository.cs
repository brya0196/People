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
    public class PersonRepository : IPerson
    {
        private readonly PeopleDbContext _context;

        public PersonRepository(PeopleDbContext context)
        {
            _context = context;
        }

        public async Task Add(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int Id)
        {
            var person = GetById(Id);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.People;
        }

        public Person GetById(int Id)
        {
            return _context.People.Where(p => p.Id == Id).First();
        }

        public async Task Update(Person person)
        {
            var personFromDb = GetById(person.Id);
            person.Identification = person.Identification;
            personFromDb.Name = person.Name;
            personFromDb.LastName = person.LastName;
            personFromDb.Phone = person.Phone;
            personFromDb.Birthdate = person.Birthdate;
            await _context.SaveChangesAsync();
        }
    }
}
