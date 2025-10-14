using Microsoft.Data.Sqlite;
using MovieQuiz.Models;

namespace MovieQuiz.Data
{
    public static class QuestionRepository
    {
        public static List<Question> GetAllQuestions()
        {
            var questions = new List<Question>();

            try

            {
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                var sql = "SELECT * FROM questions";
                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    questions.Add(new Question
                    {
                        Id = reader.GetInt32(0),
                        Category = reader.GetString(1),
                        Text = reader.GetString(2),
                        Options = new string[]
                        {
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6)
                        },
                        CorrectOption = reader.GetInt32(7)
                    });
                }
            }
            catch (SqliteException e)
            {
                Console.WriteLine($"Error fetching questions: {e.Message}");
            }

            return questions;
        }
    }
}