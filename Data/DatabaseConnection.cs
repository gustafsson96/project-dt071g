using static System.Console;
using Microsoft.Data.Sqlite;

namespace QuizApp.Data
{
    public class DatabaseConnection
    {
        public static void InitializeDatabase()
        {
            // SQL command to create a table for storing quiz questions
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
                Create new conenction in try catch block
                Guide used to set up the connection:
                https://www.sqlitetutorial.net/sqlite-csharp/connect/
            */
            try
            {
                // Create connection to quiz.db inside the project folder
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                // Execute the SQL command to create the questions table in quiz.db (if it doesn't exist)
                using var command = new SqliteCommand(sql, connection);
                command.ExecuteNonQuery();

            }
            catch (SqliteException e)
            {
                // Print error message
                WriteLine(e.Message);
            }
        }
    }
}
