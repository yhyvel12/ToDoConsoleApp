using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Console_App.Models;
using ToDo_Console_App.Services.Interfaces;

namespace ToDo_Console_App.Services.Implementations
{
    public class TaskManager : ITaskManager
    {
        private List<TaskItem> tasks;

        public TaskManager(List<TaskItem> tasks)
        {
            this.tasks = tasks;
        }

        public void Add(TaskItem item)
        {
            tasks.Add(item);
        }

        public int Complete(int taskId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = true;
                return task.Id; // Return the ID of the completed task
            }
            else
            {
                Console.WriteLine("Task not found!");
                return -1; // Indicate failure
            }
        }

        public void Delete(int itemId)
        {
            var task = tasks.FirstOrDefault(t => t.Id == itemId);
            if (task != null)
            {
                tasks.Remove(task);
            }
            else
            {
                Console.WriteLine("Task not found!");
            }
        }

        public List<TaskItem> Show()
        {
            return tasks;
        }

        public int Update(TaskItem item)
        {
            var task = tasks.FirstOrDefault(t => t.Id == item.Id);
            if (task != null)
            {
                task.Title = item.Title;
                task.Description = item.Description;
                task.IsCompleted = item.IsCompleted;
                return task.Id; // Return the ID of the updated task
            }
            else
            {
                Console.WriteLine("Task not found!");
                return -1; // Indicate failure
            }
        }
    }
}
