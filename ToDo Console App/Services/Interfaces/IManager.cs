using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Console_App.Models.Interfaces;

namespace ToDo_Console_App.Services.Interfaces
{
    public interface IManager<T> where T : IModel
    {
        void Add(T item);
        int Update(T item);
        void Delete(int itemId);
        List<T> Show();
    }
}
