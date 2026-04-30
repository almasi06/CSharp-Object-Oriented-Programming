using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrganizerApp
{
    public class InvalidLoginException : Exception   //Custom exceptions for clarity 
    {
        public InvalidLoginException(string message) : base(message) { }
    }

    public class TaskNotFoundException : Exception { }
}
