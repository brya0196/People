using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Data.Interface
{
    public interface IResidence
    {
        IEnumerable<Residence> GetAll();
        Residence GetById(int Id);
        Task Add(Residence province);
        Task Update(Residence province);
        Task Delete(int Id);
    }
}
