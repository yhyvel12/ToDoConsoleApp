using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Console_App.Models;
using ToDo_Console_App.Services.Interfaces;

namespace ToDo_Console_App.Services.Implementations
{
    public class UserManager : IUserManager
    {
        private List<User> users = new List<User>();

        public void Add(User item)
        {
            users.Add(item);
        }

        public void Delete(int itemId)
        {
            var user = users.FirstOrDefault(u => u.Id == itemId);
            if (user != null)
            {
                users.Remove(user);
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        public List<User> Show()
        {
            return users;
        }

        public int Update(User item)
        {
            var user = users.FirstOrDefault(u => u.Id == item.Id);
            if (user != null)
            {
                user.Username = item.Username;
                user.IsAdmin = item.IsAdmin;
                return user.Id; // Return the ID of the updated user
            }
            else
            {
                Console.WriteLine("User not found!");
                return -1; // Indicate failure
            }
        }
    }
}
