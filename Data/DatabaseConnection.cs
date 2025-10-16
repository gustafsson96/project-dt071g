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
            category TEXT NOT NULL,
            question TEXT NOT NULL,
            first_alternative TEXT NOT NULL,
            second_alternative TEXT NOT NULL,
            third_alternative TEXT NOT NULL,
            fourth_alternative TEXT NOT NULL,
            correct_alternative INTEGER NOT NULL
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

                WriteLine("Connected to the SQLite database...");

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

        // A TEST CLASS to see if inserting a question to the database works
        public static void InsertQuestion()
        {


        }
    }
}
