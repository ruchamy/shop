using Games.Core;
using Games.Core.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Data.data
{
    public class UserData : IUserData
    {
        private readonly DataContext dataContext;
        public UserData(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public void addUser(User user)
        {
            dataContext.users.Add(user);
            dataContext.SaveChanges();
        }
        //פונקציה אסינכרונית
        public async Task<List<User>> getAll()
        {
            return await dataContext.users.ToListAsync();
        }

        public User getById(int id)
        {
            return dataContext.users.FirstOrDefault(x => x.Id == id)!;

        }

        public User getByUserNameAndPassword(string name, string password)
        {
            return dataContext.users.FirstOrDefault(x => x.UserName == name && x.Password == password)!;
        }

        public void removeUser(int id)
        {
            User u = getById(id);
            if (u != null)
            {
                dataContext.users.Remove(u);
                dataContext.SaveChanges();
            }
        }

        public void updateUser(User user)
        {
            User u = getById(user.Id);
            if (u != null)
            {
                u.UserName = user.UserName;
                u.Password = user.Password;
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Phone = user.Phone;
                u.Address = user.Address;
                u.Email = user.Email;
                dataContext.SaveChanges();
            }
        }
    }
}
