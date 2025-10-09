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

                WriteLine("Connected to the SQLite database!");

                using var command = new SqliteCommand(sql, connection);
                command.ExecuteNonQuery();
                WriteLine("Table questions was created successfully!");

            }
            catch (SqliteException e)
            {
                WriteLine(e.Message);
            }
        }

        public static void InsertQuestion()
        {
            
        }
    }
}
