using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Core.service
{
    public interface IUserService
    {
        //פונקציה אסינכרונית
        Task<List<User>> getAll();
        User getByUserNameAndPassword(string name, string password);
        User getById(int id);
        void addUser(User user );
        void updateUser(User user);
        void removeUser(int id);
    }
}
