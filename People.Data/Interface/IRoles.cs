using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Data.Interface
{
    public interface IRoles
    {
        IEnumerable<Role> GetAll();
        Role GetById(int Id);
        Task Add(Role role);
        Task Update(Role role);
        Task Delete(int Id);
    }
}
