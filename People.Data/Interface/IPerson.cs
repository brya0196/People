using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Data.Interface
{
    public interface IPerson
    {
        IEnumerable<Person> GetAll();
        Person GetById(int Id);
        Task Add(Person person);
        Task Update(Person person);
        Task Delete(int Id);
    }
}
