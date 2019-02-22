using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Data.Interface
{
    public interface IProvince
    {
        IEnumerable<Province> GetAll();
        Province GetById(int Id);
        Task Add(Province province);
        Task Update(Province province);
        Task Delete(int Id);
    }
}
