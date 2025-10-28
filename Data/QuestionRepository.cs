using Microsoft.Data.Sqlite;
using QuizApp.Models;
using static System.Console;

namespace QuizApp.Data
{
    // Handles database operations related to quiz quetions
    public static class QuestionRepository
    {
        // Collects all quiz questions from the SQLite database
        public static List<Question> GetAllQuestions()
        {
            var questions = new List<Question>();

            try
            {
                // Open the connection to the quiz.db file
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                // SQL command to retrieve all records from the questions table
                var sql = "SELECT * FROM questions";
                using var command = new SqliteCommand(sql, connection);

                // Execute the command
                using var reader = command.ExecuteReader();

                // Loop through each row and map the data to a Question object using reader
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

        // Inserts a new question into the database
        // Includes validation to prevent saving empty of incomplete entries
        public static void InsertQuestion(Question question)
        {
            // Ensure all fields are filled put
            if (string.IsNullOrWhiteSpace(question.Category) ||
            string.IsNullOrWhiteSpace(question.Text) ||
            question.Options.Any(option => string.IsNullOrWhiteSpace(option)))
            {
                WriteLine("Error: Question contains empty fields and was not saved.");
                return;
            }

            try
            {
                // Open the connection to the quiz.db file
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                // SQL command to insert a new question into the questions table
                var sql = @"INSERT INTO questions (category, question, first_alternative, second_alternative, third_alternative, fourth_alternative, correct_alternative)
                          VALUES (@category, @question, @first, @second, @third, @fourth, @correct)";

                // Prepare the command by binding the parameters to user input (protection against SQL injections)
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@category", question.Category);
                command.Parameters.AddWithValue("@question", question.Text);
                command.Parameters.AddWithValue("@first", question.Options[0]);
                command.Parameters.AddWithValue("@second", question.Options[1]);
                command.Parameters.AddWithValue("@third", question.Options[2]);
                command.Parameters.AddWithValue("@fourth", question.Options[3]);
                command.Parameters.AddWithValue("@correct", question.CorrectOption);

                // Execute the command and return a number of affected rows
                command.ExecuteNonQuery();

                WriteLine("Question added successfully.");
            }
            catch (SqliteException e)
            {
                WriteLine(e.Message);
            }
        }
        
        // Deletes a question from the database based on ID
        public static void DeleteQuestion(int id)
        {
            try
            {
              // Open the connection to the quiz.db file
                using var connection = new SqliteConnection("Data Source=quiz.db");
                connection.Open();

                // SQL command to delete a question by ID
                var sql = "DELETE FROM questions WHERE id = @id";
                using var command = new SqliteCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                // Execute the command and ensure at least one row was affected
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