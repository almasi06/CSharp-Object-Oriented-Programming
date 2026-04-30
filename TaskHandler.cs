using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrganizerApp
{
    public class TaskHandler : ITaskStorage   //Implements storage using a list
    {
        private List<Task> tasks = new List<Task>();

        public void AddTask(Task task)
        {
            tasks.Add(task);   //Adds the tasks to the list
            tasks.Sort((x, y) => x.DueDate.CompareTo(y.DueDate));   //Sort the tasks by due date
            Console.WriteLine($"Task '{task.Title}' added successfully.");
        }

        public void RemoveTask(string taskTitle)
        {
            int removed = tasks.RemoveAll(t => t.Title.Equals(taskTitle, StringComparison.OrdinalIgnoreCase));
            if (removed == 0)
                throw new TaskNotFoundException();   //Task not found 
            Console.WriteLine($"Task '{taskTitle}' removed successfully.");
        }

        public List<Task> GetAllTasks()
        {
            return tasks;   //Shows all the tasks
        }
    }
}
