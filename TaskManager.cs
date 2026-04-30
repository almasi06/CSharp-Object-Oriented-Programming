using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOrganizerApp;


    

    namespace TaskOrganizerApp
    {
        public class TaskManager   //Handles the task operations and events
        {
            private ITaskStorage storage = new TaskHandler();  //Storage for tasks
            public event Action<Task> DeadlineAlert;  //Event triggered for tasks that is due soon

            public void AddTask(Task task) => storage.AddTask(task);   //Adds the task
            public void RemoveTask(string taskTitle) => storage.RemoveTask(taskTitle);   //Removes the task
            public List<Task> GetAllTasks() => storage.GetAllTasks();   //Shows all the tasks

            public void CheckDeadlines()   //Check the deadline and trigger the event for the upcoming tasks
            {
                foreach (var task in storage.GetAllTasks())
                {
                    if (!task.Completed && (task.DueDate - DateTime.Now).TotalDays <= 1)   //Notifies if the task is due in 1 day
                    {
                        DeadlineAlert?.Invoke(task);
                    }
                }
            }
        }
    }


