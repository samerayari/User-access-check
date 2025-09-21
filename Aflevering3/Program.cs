using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        Console.Write("Enter userId: ");
        string input = Console.ReadLine();

        uint userId;
        if (!uint.TryParse(input, out userId))
        {
            Console.WriteLine("Access denied. Invalid userId. Must be a positive number.");
            return;
        }

        
        bool userIsAdmin = userId > 65536;

       
        bool usernameValid = !string.IsNullOrWhiteSpace(username) && username.Length >= 3;

      
        bool passwordContainsSpecial = password.Contains('$') || password.Contains('|') || password.Contains('@');
        bool passwordLengthValid = userIsAdmin ? password.Length >= 20 : password.Length >= 16;
        bool passwordValid = passwordContainsSpecial && passwordLengthValid;

       
        if (usernameValid && passwordValid)
        {
            Console.WriteLine("Access granted!");
            if (userIsAdmin)
                Console.WriteLine("Welcome, administrator.");
            else
                Console.WriteLine("Welcome, user.");
        }
        else
        {
            Console.WriteLine("Access denied.");

            if (!usernameValid)
                Console.WriteLine("- Username must be at least 3 characters long.");

            if (!passwordContainsSpecial)
                Console.WriteLine("- Password must contain at least one of the characters $, |, @.");

            if (!passwordLengthValid)
            {
                if (userIsAdmin)
                    Console.WriteLine("- Admin password must be at least 20 characters long.");
                else
                    Console.WriteLine("- Password must be at least 16 characters long.");
            }
        }
    }
}