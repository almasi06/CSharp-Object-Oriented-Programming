using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrganizerApp
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public bool Completed { get; set; }

        public Task() { }

        public Task(string title, string description, DateTime dueDate, string priority, bool completed = false)   //Constructor for creating new tasks
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Completed = completed;
        }

        public void MarkAsCompleted()   //Method to mark the tasks as completed 
        {
            Completed = true;
            Console.WriteLine($"Task '{Title}' marked as completed on {DateTime.Now}.");
        }

        public override string ToString()
        {
            return $"Title: {Title} | Due: {DueDate.ToShortDateString()} | Priority: {Priority} | Completed: {Completed}";
        }
    }
}
