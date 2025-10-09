using static System.Console;
using Microsoft.Data.Sqlite;

namespace quizApp
{
    public class databaseConnection
    {
        public static void TestConnection()
        {
            /*
    var sql = @"CREATE TABLE questions(
        id INTEGER PRIMARY KEY,
        question TEXT NOT NULL,
        first_alternative TEXT NOT NULL,
        second_alternative TEXT NOT NULL,
        third_alternative TEXT NOT NULL,
        fourth_alternative TEXT NOT NULL
    )";
    */

            try
            {
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                /*
                using var command = new SqliteCommand(sql, connection);
                command.ExecuteNonQuery();
                WriteLine("Table questions was created successfully!");
                */

                WriteLine("Connected to the SQLite database!");
            }
            catch (SqliteException e)
            {
                WriteLine(e.Message);
            }
        }
    }
}
