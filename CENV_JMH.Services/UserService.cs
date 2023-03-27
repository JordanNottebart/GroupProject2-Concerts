using CENV_JMH.DA;
using CENV_JMH.DO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CENV_JMH.Services
{
    public class UserService
    {
        public List<User> GetUsers()
        {
            using (var repo = new Repository())
            {
                return repo.Users.ToList();
            }
        }

        public User GetUserById(int id) 
        {
            using (var repo = new Repository())
            {
                return repo.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        public void UpdateUser(User user)
        {
            using (var repo = new Repository())
            {
                repo.Attach(user);
                var e = repo.ChangeTracker.Entries().FirstOrDefault(c => c.Entity == user);
                e.State = EntityState.Modified;

                repo.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            using (var repo = new Repository())
            {
                var user = GetUserById(id);
                repo.Users.Remove(user);
                repo.SaveChanges();
            }
        }
    }
}
