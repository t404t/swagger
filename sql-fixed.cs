public void OnPost()
{
    string connectionString = "YourConnectionStringHere"; // Use your actual connection string
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();


        string sqlQuery = "SELECT * FROM Users WHERE Username = @Username"; // Use parameterized query
        SqlCommand command = new SqlCommand(sqlQuery, connection);
        command.Parameters.AddWithValue("@Username", Username); // Add parameter to command
        SqlDataReader reader = command.ExecuteReader();
        
        if (reader.Read())
        {
            SearchResult = $"User found: {reader["Username"]} - {reader["Email"]}";
        }
        else
        {
            SearchResult = "User not found.";
        }
    }
}
