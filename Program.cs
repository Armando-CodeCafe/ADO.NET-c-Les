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
            User u = new User();
            Console.WriteLine("Please fill in your email");
            u.email = Console.ReadLine();
            Console.WriteLine("Please fill in your password");
            u.password = Console.ReadLine();
            bool loggedIn = u.Login();
            if (loggedIn)
            {
                //gebruiker is succesvol ingelogd 
            }
        }


    }
}
