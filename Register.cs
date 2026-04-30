using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrganizerApp
{
    public class Register
    {

        string Name;
        string Passwords;

       

        internal Dictionary<string, string> accounts = new Dictionary<string, string>();    //Dictionary to store accounts: the username as key and password as value

        public Dictionary<string, string> Accounts => accounts;

        public void SignUp()    //MEthod to sign up new users
        {
            string username;
            do
            {
                Console.Write("Enter username: ");
                username = Console.ReadLine();
                if (accounts.ContainsKey(username))
                    Console.WriteLine("Username already exists. Try a different one.");
            } while (accounts.ContainsKey(username));

            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            accounts[username] = password;    //Saves the new accounts
            Console.WriteLine("Account created successfully!");
        }
    }
}
