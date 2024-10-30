namespace ADO;
using MySqlConnector;
class Program
{
    static void Main(string[] args)
    {

        //login menu
        Console.WriteLine("Do you want to login or register?");
        string choice = Console.ReadLine();
        if (choice == "register")
        {
            //maak een user object aan voor de nieuwe gebruiker
            User u = new User();
            Console.WriteLine("Please fill in your username");
            u.username = Console.ReadLine();
            Console.WriteLine("Please fill in your email");
            u.email = Console.ReadLine();
            Console.WriteLine("Please fill in your password");
            u.password = Console.ReadLine();
            //sla de gebruiker op in de database met een (C)rud functie op de User
            u.Create();
        }
        else if (choice == "login")
        {
            //maak een user object aan die de ingelogde user gaat opslaan
            User loggedInUser = new User();
            Console.WriteLine("Please fill in your email");
            loggedInUser.email = Console.ReadLine();
            Console.WriteLine("Please fill in your password");
            loggedInUser.password = Console.ReadLine();
            //gebasseerd op of de user correct of incorrect heeft ingevuld, maak een boolean met de waarde true of false
            bool loggedIn = loggedInUser.Login();
            //zolang de gebruiker ingelogd is, blijf het update menu laten zien
            while (loggedIn)
            {

                Console.WriteLine($"Logged in as user {loggedInUser.username} with email {loggedInUser.email} and id {loggedInUser.id}\n");

                Console.WriteLine("Choose what you want to do:\n1. Change username\n2. Change email\n3. Change password");

                string option = Console.ReadLine();
                if (option == "1")
                {
                    //edit de gebruikers naam met een nieuwe input
                    Console.WriteLine("Please fill in your new username");
                    loggedInUser.username = Console.ReadLine();
                    //update dit zodat het ook in de database gebeurt
                    loggedInUser.Update();
                }
                //alle code hieronder is hetzelfde als optie 1 maar dan met een andere waarde
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
