using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Data.Interface
{
    public interface IKindService
    {
        IEnumerable<KindService> GetAll();
        KindService GetById(int Id);
        Task Add(KindService kindService);
        Task Update(KindService kindService);
        Task Delete(int Id);
    }
}
