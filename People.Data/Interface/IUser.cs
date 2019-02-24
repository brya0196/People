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
        Task Add(User user);
        Task Update(User user);
        Task Delete(int Id);
        Task ChangePassword(int Id, string newPassword);
    }
}
