using TaskOrganizerApp;
using System;
using System.Linq;


namespace TaskOrganizerApp
{
    class Program
    {
        static void Main()
        {
            Register register = new Register();
            register.SignUp();     //Creating of the user account

            
            var firstAccount = register.Accounts.First();   //Use the first registered account for demo login 
            User user = new User(firstAccount.Key, firstAccount.Value);

            int maxAttempts = 3, attempts = 0;     //How many times you can fail to login
            while (attempts < maxAttempts)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                try
                {
                    user.Login(username, password);   //Login validation 
                    break;    //Exit the loop when the login was successful
                }
                catch (InvalidLoginException ex)
                {
                    attempts++;
                    Console.WriteLine($"Login failed: {ex.Message} Attempts left: {maxAttempts - attempts}");
                }
            }

            if (attempts >= maxAttempts)
            {
                Console.WriteLine("Access denied. Exiting program.");
                return;    //Exits the program when the max attempts exceeds
            }

            Console.WriteLine("Login successful! Welcome to Task Manager.");

            TaskManager manager = new TaskManager();
            manager.DeadlineAlert += (task) => Console.WriteLine($"Reminder: Task '{task.Title}' is due soon!");   //Subscribe to deadline alert

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nTask Manager Menu");
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. View all tasks");
                Console.WriteLine("3. Mark task completed");
                Console.WriteLine("4. Remove task");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":   //Add new task
                        Console.Write("Title: "); string t = Console.ReadLine();
                        Console.Write("Description: "); string d = Console.ReadLine();
                        Console.Write("Due date (yyyy-MM-dd): "); DateTime dt = DateTime.Parse(Console.ReadLine());
                        Console.Write("Priority (1-Low, 2-Medium , 3-High): "); string p = Console.ReadLine();
                        Task newTask = new Task(t, d, dt, p, false);
                        manager.AddTask(newTask);
                        Console.WriteLine("Task added successfully!");
                        break;

                    case "2":    //View all tasks
                        var tasks = manager.GetAllTasks();
                        if (!tasks.Any()) Console.WriteLine("No tasks available.");
                        else tasks.ForEach(tsk => Console.WriteLine(tsk));
                        break;

                    case "3":   //Mark task as completed
                        Console.Write("Enter task title to complete: ");
                        string completeTitle = Console.ReadLine();
                        var taskToComplete = manager.GetAllTasks().FirstOrDefault(t => t.Title == completeTitle);
                        if (taskToComplete != null)
                        {
                            taskToComplete.MarkAsCompleted();
                        }
                        else Console.WriteLine("Task not found.");
                        break;

                    case "4":   //Remove task
                        Console.Write("Enter task title to remove: ");
                        string removeTitle = Console.ReadLine();
                        try
                        {
                            manager.RemoveTask(removeTitle);
                            Console.WriteLine("Task removed successfully.");
                        }
                        catch (TaskNotFoundException)
                        {
                            Console.WriteLine("Task not found.");
                        }
                        break;
                         
                    case "5":    //Exits the program
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                manager.CheckDeadlines();    //Checks the deadlines after each operation done
            }

            Console.WriteLine("Exiting Task Manager. Goodbye!");
        }
    }
}
