using static System.Console;
using Microsoft.Data.Sqlite;

namespace quizApp
{
    public class databaseConnection
    {
        public static void InitializeDatabase()
        {

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


            try
            {
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                WriteLine("Connected to the SQLite database...");

                using var command = new SqliteCommand(sql, connection);
                command.ExecuteNonQuery();

            }
            catch (SqliteException e)
            {
                WriteLine(e.Message);
            }
        }

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
