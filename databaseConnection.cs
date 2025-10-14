using static System.Console;
using Microsoft.Data.Sqlite;

namespace MovieQuiz
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
            try
            {
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                var sql = @"INSERT INTO questions 
                    (category, question, first_alternative, second_alternative, third_alternative, fourth_alternative, correct_alternative) 
                    VALUES (@category, @question, @first, @second, @third, @fourth, @correct)";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@category", "General Knowledge");
                command.Parameters.AddWithValue("@question", "What is the capital of France?");
                command.Parameters.AddWithValue("@first", "Paris");
                command.Parameters.AddWithValue("@second", "Rome");
                command.Parameters.AddWithValue("@third", "Berlin");
                command.Parameters.AddWithValue("@fourth", "Madrid");
                command.Parameters.AddWithValue("@correct", 1);

                int result = command.ExecuteNonQuery();
                WriteLine($"{result} question inserted successfully!");
            }
            catch (SqliteException e)
            {
                WriteLine($"Error inserting question: {e.Message}");
            }
        }
    }
}
