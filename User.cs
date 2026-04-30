using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrganizerApp
{
    public class User
    {
        private string username;
        private string password;

        public string Username
        {
            get => username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username cannot be blank.");
                username = value;
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Password cannot be blank.");
                password = value;
            }
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void Login(string enteredUsername, string enteredPassword)    //Validates the login
        {
            if (string.IsNullOrWhiteSpace(enteredUsername) || string.IsNullOrWhiteSpace(enteredPassword))
                throw new InvalidLoginException("Username and Password cannot be empty.");

            if (enteredUsername != username || enteredPassword != password)
                throw new InvalidLoginException("Username or Password is incorrect.");

            Console.WriteLine($"Welcome back {username}!");
        }
    }
}
