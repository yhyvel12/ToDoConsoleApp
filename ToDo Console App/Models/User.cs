using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Console_App.Models.Interfaces;

namespace ToDo_Console_App.Models
{
    public class User : IModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }

        public User(int id, string username, bool isAdmin)
        {
            Id = id;
            Username = username;
            IsAdmin = isAdmin;
        }
    }
}
