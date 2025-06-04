using Games.Core;
using Games.Core.data;
using Games.Core.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Service
{
    public class UserService : IUserService
    {
        private readonly IUserData userData;
        public UserService(IUserData _userData)
        {
            userData = _userData;
        }
        public void addUser(User user)
        {
            userData.addUser(user);
        }
        //פונקציה אסינכרונית
        public async Task<List<User>> getAll()
        {
            return await userData.getAll();
        }

        public User getById(int id)
        {
            return userData.getById(id);
        }

        public User getByUserNameAndPassword(string name, string password)
        {
            return userData.getByUserNameAndPassword(name, password);
        }

        public void removeUser(int id)
        {
            userData.removeUser(id);
        }

        public void updateUser(User user)
        {
            userData.updateUser(user);
        }
    }
}
