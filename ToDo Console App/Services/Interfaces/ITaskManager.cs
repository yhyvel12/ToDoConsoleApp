using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Console_App.Models;

namespace ToDo_Console_App.Services.Interfaces
{
    public interface ITaskManager : IManager<TaskItem>
    {
        int Complete(int taskId);
    }
}
