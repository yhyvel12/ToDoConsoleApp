using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo_Console_App.Models;
using ToDo_Console_App.Services.Implementations;

namespace ToDo_Console_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>
                       {
                           new User(1,"jessica", true),
                           new User(2,"john", false),
                           new User(3, "jane", false)
                       };

            List<TaskItem> tasks = new List<TaskItem>
                       {
                           new TaskItem(1, "Buy groceries", "Buy milk, eggs, and bread"),
                           new TaskItem(2, "Complete project report", "Finish the report for the project due next week"),
                           new TaskItem(3, "Call mom", "Check in with mom and see how she's doing")
                       };

            Console.WriteLine("Enter your username:");
            string inputUsername = Console.ReadLine();

            User currentUser = users.Find(u => u.Username.Equals(inputUsername, StringComparison.OrdinalIgnoreCase));

            if (currentUser == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            if (!currentUser.IsAdmin)
            {
                Console.WriteLine("Access denied. Only admin users can access the system.");
                return;
            }

            Console.WriteLine($"Welcome, {currentUser.Username}! You have admin access.");
            Console.WriteLine("----------------");

            TaskManager taskManager = new TaskManager(tasks);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Show all tasks");
                Console.WriteLine("2. Complete a task");
                Console.WriteLine("3. Add new task");
                Console.WriteLine("4. Delete a task");
                Console.WriteLine("5. Update a task");
                Console.WriteLine("0. Exit");

                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var allTasks = taskManager.Show();
                        foreach (var task in allTasks)
                        {
                            Console.WriteLine($"ID: {task.Id} | Title: {task.Title} | Description: {task.Description} | Completed: {(task.IsCompleted ? "Yes" : "No")}");
                        }
                        Console.WriteLine("----------------");

                        break;

                    case "2":
                        Console.Write("Enter task ID to complete: ");
                        if (int.TryParse(Console.ReadLine(), out int completeId))
                        {
                            var taskToUpdate = tasks.FirstOrDefault(t => t.Id == completeId);
                            if (taskToUpdate != null)
                            {
                                taskToUpdate.IsCompleted = true;
                                taskManager.Update(taskToUpdate);
                                Console.WriteLine("Task marked as completed.");
                            }
                            else
                            {
                                Console.WriteLine("Task not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        Console.WriteLine("----------------");

                        break;

                    case "3":
                        Console.Write("Enter task title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        int newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
                        TaskItem newTask = new TaskItem(newId, title, description);
                        taskManager.Add(newTask);
                        Console.WriteLine("Task added.");
                        Console.WriteLine("----------------");

                        break;

                    case "4":
                        Console.Write("Enter task ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            taskManager.Delete(deleteId);
                            Console.WriteLine("Task deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        Console.WriteLine("----------------");

                        break;

                    case "5":
                        Console.Write("Enter task ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            var existingTask = tasks.FirstOrDefault(t => t.Id == updateId);
                            if (existingTask != null)
                            {
                                Console.Write("Enter new title (leave empty to keep current): ");
                                string newTitle = Console.ReadLine();
                                Console.Write("Enter new description (leave empty to keep current): ");
                                string newDescription = Console.ReadLine();
                                Console.Write("Is the task completed? (yes/no, leave empty to keep current): ");
                                string completedInput = Console.ReadLine();

                                if (!string.IsNullOrWhiteSpace(newTitle))
                                    existingTask.Title = newTitle;

                                if (!string.IsNullOrWhiteSpace(newDescription))
                                    existingTask.Description = newDescription;

                                if (!string.IsNullOrWhiteSpace(completedInput))
                                    existingTask.IsCompleted = completedInput.Trim().ToLower() == "yes";

                                taskManager.Update(existingTask);
                                Console.WriteLine("Task updated.");
                            }
                            else
                            {
                                Console.WriteLine("Task not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        Console.WriteLine("----------------");
                        break;

                    case "0":
                        Console.WriteLine("Exiting...");
                        Console.WriteLine("Have a nice day!!");
                        Console.WriteLine("----------------");

                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Console.WriteLine("----------------");

                        break;
                }
            }

        }
    }
}
