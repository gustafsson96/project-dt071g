using Microsoft.Data.Sqlite;
using QuizApp.Models;
using static System.Console;

namespace QuizApp.Data
{
    public static class QuestionRepository
    {
        // Fetch all questions from the database
        public static List<Question> GetAllQuestions()
        {
            var questions = new List<Question>();

            try

            {
                // Connect to the database
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                // Select all questions
                var sql = "SELECT * FROM questions";
                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();

                // Read each row and create Question objects
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
                WriteLine($"Error fetching questions: {e.Message}");
            }

            return questions;
        }

        // Method to insert question into the database
        public static void InsertQuestion(Question question)
        {
            if (string.IsNullOrWhiteSpace(question.Category) ||
            string.IsNullOrWhiteSpace(question.Text) ||
            question.Options.Any(option => string.IsNullOrWhiteSpace(option)))
            {
                WriteLine("Error: Question contains empty fields and was not saved.");
                return;
            }

            try
            {
                // Create and open a connection to the database
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                // SQL query to insert a new question
                var sql = @"INSERT INTO questions (category, question, first_alternative, second_alternative, third_alternative, fourth_alternative, correct_alternative)
            VALUES (@category, @question, @first, @second, @third, @fourth, @correct)";

                // Create a command and bind the parameters to user input (data from the Question object)
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@category", question.Category);
                command.Parameters.AddWithValue("@question", question.Text);
                command.Parameters.AddWithValue("@first", question.Options[0]);
                command.Parameters.AddWithValue("@second", question.Options[1]);
                command.Parameters.AddWithValue("@third", question.Options[2]);
                command.Parameters.AddWithValue("@fourth", question.Options[3]);
                command.Parameters.AddWithValue("@correct", question.CorrectOption);

                // Execute the command to insert a new question
                command.ExecuteNonQuery();

                WriteLine("Question added successfully.");
            }
            catch (SqliteException e)
            {
                WriteLine(e.Message);
            }
        }

        public static void DeleteQuestion(int id)
        {
            try
            {
                // Create and open a connection to the database
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                // SQL query to delete a question based on id
                var sql = "DELETE FROM questions WHERE id = @id";

                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                // Execute the command to delete a question
                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    Clear();
                    WriteLine($"Question with ID {id} was deleted successfully\n");
                }
                else
                {
                    WriteLine("No question found with that ID.");
                }
            }
            catch (SqliteException e)
            {
                WriteLine(e.Message);
            }
        }
    }
}