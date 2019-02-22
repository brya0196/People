using People.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Data.Interface
{
    public interface IUser
    {
        IEnumerable<User> GetAll();
        User GetById(int Id);
        Task Add(User province);
        Task Update(User province);
        Task Delete(int Id);
    }
}
