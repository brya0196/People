using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Data.Interface
{
    public interface ICity
    {
        IEnumerable<City> GetAll();
        City GetById(int Id);
        Task Add(City city);
        Task Update(City city);
        Task Delete(int Id);

        IEnumerable<City> GetByIdProvince(int Id);
    }
}
