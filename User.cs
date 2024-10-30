using MySqlConnector;

class User
{
    public int id;
    public string username;
    public string email;
    public string password;
    public bool isAdmin;
    //(C)rud functie, pakt de gegevens van de user waar de functie op wordt aangeroepen en voert een insert query ermee uit
    public void Create()
    {
        //database connect
        MySqlConnection connection = new MySqlConnection(
            "Server=localhost;Database=NativeDb;User=root;"
            );
        connection.Open();
        //query initializatie
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Users(username,email,password) VALUES(@username,@email,@password)";
        //variabelen en parameters invullen voor de query
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@password", password);
        //voer de query uit, maar verwacht geen rijen of resultaten
        command.ExecuteNonQuery();
        //sluit de database weer af
        connection.Close();
    }
    //C(R)UD kijk of de huigide email en password in de database zitten bij een gebruiker, en return dan true of false als het gelukt is
    public bool Login()
    {
        MySqlConnection connection = new MySqlConnection(
            "Server=localhost;Database=NativeDb;User=root;"
            );
        connection.Open();

        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Users WHERE email = @email AND password = @password";
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@password", password);
        //dit keer moeten we wel uitlezen dus gebruiken we reader
        MySqlDataReader reader = command.ExecuteReader();
        //als onze query een database resultaat had zal deze functie true terug geven
        if (reader.Read())
        {
            //update de id en username van de user instantie in ons script met de id en username uit de database
            id = (int)reader["id"];
            username = (string)reader["username"];
            connection.Close();

            return true;
        }
        //er was geen gebruiker met die gegevens
        else
        {
            Console.WriteLine("login info incorrect");
            connection.Close();

            return false;
        }

    }
    //CR(U)D bijna hetzelfde als Create, maar update de gebruiker inplaats van een nieuwe te inserten. Hiervoor is het wel belangrijk dat de user.id variable geset is
    public void Update()
    {
        MySqlConnection connection = new MySqlConnection(
            "Server=localhost;Database=NativeDb;User=root;"
            );
        connection.Open();

        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE Users SET username = @username, email = @email, password = @password WHERE id = @id";
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        connection.Close();
    }
}