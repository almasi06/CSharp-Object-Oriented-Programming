using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrganizerApp
{
    public interface ITaskStorage   //Interface for task storage methods
    {
        void AddTask(Task task);
        void RemoveTask(string taskTitle);
        List<Task> GetAllTasks();
    }
}
