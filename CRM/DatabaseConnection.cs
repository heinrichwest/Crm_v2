using System;
using MySql.Data.MySqlClient;

namespace CRM
{
    public class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection()
        {
            // Update with your MySQL details
            connectionString = "Server=localhost;Database=crm_database;Uid=root;Pwd=Zuluzaan1!;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Ensures the required tables exist in the database. If they do not,
        /// they will be created with the expected schema.
        /// </summary>
        public void EnsureTables()
        {
            try
            {
                using var connection = GetConnection();
                connection.Open();

                using var command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Users (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(255) NOT NULL,
                        Email VARCHAR(255) NOT NULL
                    );";
                command.ExecuteNonQuery();

                command.CommandText = @"CREATE TABLE IF NOT EXISTS Clients (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(255) NOT NULL,
                        Email VARCHAR(255) NOT NULL
                    );";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log to console but do not crash the application during startup
                Console.WriteLine($"Database initialization failed: {ex.Message}");
            }
        }
    }
}