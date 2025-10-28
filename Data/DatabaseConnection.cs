using static System.Console;
using Microsoft.Data.Sqlite;

namespace QuizApp.Data
{
    // Handles the creation and initialization of the SQLite database used to store questions
    public class DatabaseConnection
    {
        // Creates the questions table if it does not already exist
        public static void InitializeDatabase()
        {
            var sql = @"CREATE TABLE IF NOT EXISTS questions (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            category TEXT NOT NULL CHECK (trim(category) <> ''),
            question TEXT NOT NULL CHECK (trim(question) <> ''),
            first_alternative TEXT NOT NULL CHECK (trim(first_alternative) <> ''),
            second_alternative TEXT NOT NULL CHECK (trim(second_alternative) <> ''),
            third_alternative TEXT NOT NULL CHECK (trim(third_alternative) <> ''),
            fourth_alternative TEXT NOT NULL CHECK (trim(fourth_alternative) <> ''),
            correct_alternative INTEGER NOT NULL CHECK (correct_alternative BETWEEN 1 AND 4)
)";

            /* 
                Establish connection to the local SQLite database (quiz.db)
                using the Microsoft.Data.Sqlite-package.
                Guide used to set up the connection:
                https://www.sqlitetutorial.net/sqlite-csharp/connect/
            */
            try
            {
                // Open the connection to the quiz.db file
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                // Execute the SQL command to create the table (if it doesn't already exist)
                using var command = new SqliteCommand(sql, connection);
                command.ExecuteNonQuery();

            }
            catch (SqliteException e)
            {
                // Print error message if connection fails
                WriteLine(e.Message);
            }
        }
    }
}
