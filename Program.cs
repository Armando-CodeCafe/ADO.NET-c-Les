namespace ADO;
using MySqlConnector;
class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("Do you want to login or register?");
        string choice = Console.ReadLine();
        if (choice == "register")
        {
            User u = new User();
            Console.WriteLine("Please fill in your username");
            u.username = Console.ReadLine();
            Console.WriteLine("Please fill in your email");
            u.email = Console.ReadLine();
            Console.WriteLine("Please fill in your password");
            u.password = Console.ReadLine();
            u.Create();
        }
        else if (choice == "login")
        {
            User loggedInUser = new User();
            Console.WriteLine("Please fill in your email");
            loggedInUser.email = Console.ReadLine();
            Console.WriteLine("Please fill in your password");
            loggedInUser.password = Console.ReadLine();
            bool loggedIn = loggedInUser.Login();
            while (loggedIn)
            {

                //gebruiker is succesvol ingelogd 
                Console.WriteLine($"Logged in as user {loggedInUser.username} with email {loggedInUser.email} and id {loggedInUser.id}\n");

                Console.WriteLine("Choose what you want to do:\n1. Change username\n2. Change email\n3. Change password");

                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("Please fill in your new username");
                    loggedInUser.username = Console.ReadLine();
                    loggedInUser.Update();
                }
                else if (option == "2")
                {
                    Console.WriteLine("Please fill in your new email");
                    loggedInUser.email = Console.ReadLine();
                    loggedInUser.Update();
                }
                else if (option == "3")
                {
                    Console.WriteLine("Please fill in your new password");
                    loggedInUser.password = Console.ReadLine();
                    loggedInUser.Update();
                }

            }
        }


    }
}
