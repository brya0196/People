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
        Task Add(Service service);
        Task Update(Service service);
        Task Delete(int Id);
    }
}
