// QUIZ LOGIC

using Microsoft.VisualBasic;
using QuizApp.Data;
using static System.Console;

namespace QuizApp.Services
{
    public class Quiz
    {
        // Method to start the quiz
        public void StartQuiz()
        {
            var questions = QuestionRepository.GetAllQuestions();

            // Check if there are questions in the database
            if (questions.Count == 0)
            {
                WriteLine("No questions found in the database");
                ReadKey();
                return;
            }

            // Shuffle questions and take 10 for this round
            var random = new Random();
            var quizQuestions = questions.OrderBy(q => random.Next()).Take(10).ToList();

            // Variable to store the user's points
            int score = 0;

            // Loop through the questions 
            foreach (var q in quizQuestions)
            {
                Clear();
                WriteLine($"[Category: {q.Category}]\n");
                WriteLine($"\n{q.Text}\n");

                // Loop through and present the alternatives for a question
                for (int i = 0; i < q.Options.Length; i++)
                {
                    WriteLine($"  {i + 1}. {q.Options[i]}");
                }

                // User input
                Write("\nYour answer: ");
                int answer;
                // Ensure user input is valid
                while (!int.TryParse(ReadLine(), out answer) || answer < 1 || answer > q.Options.Length)
                {
                    Write("Invalid input, try again: ");
                }

                // Check if answer is correct and update score accordingly
                if (answer == q.CorrectOption)
                {
                    WriteLine("Correct!");
                    score++;
                }
                else
                {
                    WriteLine($"Wrong, the correct answer was: {q.Options[q.CorrectOption - 1]}");
                }

                // Keep playing by pressing a button
                WriteLine("\nPress any key for the next question...");
                ReadKey();


            }

            // Present score to user when quiz is finished
            Clear();
            WriteLine($"Quiz finished! Your score: {score}/{quizQuestions.Count}");
            WriteLine("Press any key to return to the menu...");
            ReadKey();
        }

        // Method to show all questions (to test that it works)
        public void ShowAllQuestions()
        {
            var questions = Data.QuestionRepository.GetAllQuestions();
            WriteLine($"Loaded {questions.Count} questions:\n");

            foreach (var q in questions)
            {
                WriteLine($"[{q.Category}] {q.Text}");
                for (int i = 0; i < q.Options.Length; i++)
                {
                    WriteLine($"  {i + 1}. {q.Options[i]}");
                }
                WriteLine($"(Correct: {q.CorrectOption})\n");
            }
            WriteLine("Press any key to return to the menu...");
            ReadKey();
        }
    }
}