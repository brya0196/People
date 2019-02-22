using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Data.Interface
{
    public interface IService
    {
        IEnumerable<Service> GetAll();
        Service GetById(int Id);
        Task Add(Service province);
        Task Update(Service province);
        Task Delete(int Id);
    }
}
