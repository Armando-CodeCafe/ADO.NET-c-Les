using MySqlConnector;

class User
{
    public int id;
    public string username;
    public string email;
    public string password;
    public bool isAdmin;
    public void Create()
    {
        MySqlConnection connection = new MySqlConnection(
            "Server=localhost;Database=NativeDb;User=root;"
            );
        connection.Open();

        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Users(username,email,password) VALUES(@username,@email,@password)";
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@password", password);
        command.ExecuteNonQuery();
        connection.Close();
    }

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
        MySqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            Console.WriteLine($"Logged in as user with id: " + reader["id"]);
            connection.Close();

            return true;
        }
        else
        {
            Console.WriteLine("login info incorrect");
            connection.Close();

            return false;
        }

    }
}