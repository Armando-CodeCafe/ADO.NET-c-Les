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
            id = (int)reader["id"];
            username = (string)reader["username"];
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