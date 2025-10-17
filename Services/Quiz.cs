// QUIZ LOGIC

using System.ComponentModel;
using Microsoft.VisualBasic;
using QuizApp.Data;
using static System.Console;
using System.Threading;
using QuizApp.Menus;

namespace QuizApp.Services
{
    public class Quiz
    {
        // Method to start the quiz
        public void StartQuiz(string category)
        {
            // Get a list of all questions
            var questions = QuestionRepository.GetAllQuestions();

            // Check if user picked a category other than mixed and filter questions list accordingly
            if (category != "mixed")
            {
                questions = questions.Where(q => q.Category.ToLower() == category).ToList();
            }

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
                WriteLine($"[Category: {q.Category}]");
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
                    WriteLine("\nCorrect!");
                    score++;
                }
                else
                {
                    WriteLine($"\nWrong, the correct answer was: {q.Options[q.CorrectOption - 1]}");
                }

                Write("\nPress any key for next question");
                ReadKey();
            }

            // Present score to user when quiz is finished
            // Short delay with simple loading effect before next question is displayed
            WriteLine("\nQuiz finished! Calculating your results ");
            for (int i = 0; i < 12; i++)
            {
                Write(".");
                Thread.Sleep(380);
            }
            Clear();
            WriteLine($"Your scored: {score}/{quizQuestions.Count}\n");

            while (true)
            {
                Write("\nDo you want to play again? (y/n)");
                string input = ReadLine()!.Trim().ToLower();

                if (input == "y")
                {
                    GameMenu gameMenu = new GameMenu();
                    gameMenu.ShowGameMenu();
                    break;
                }
                else if (input == "n")
                {
                    WriteLine("\nReturning to menu ");
                    for (int i = 0; i < 8; i++)
                    {
                        Write(".");
                        Thread.Sleep(350);
                    }
                    break;
                }
                else
                {
                    WriteLine("Invalid input. Please type 'y' or 'n'.");
                }
            }
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