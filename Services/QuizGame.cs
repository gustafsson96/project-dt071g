// QUIZ LOGIC

using QuizApp.Data;
using QuizApp.Menus;
using static System.Console;
using System.Threading;

namespace QuizApp.Services
{
    public class QuizGame
    {
        private readonly Random random = new Random();

        // Method to start quiz for the selected category
        public void StartQuiz(string category)
        {
            // Get a list of all questions
            var questions = LoadQuestions(category);

            // Check if there are questions in the database
            if (questions.Count == 0)
            {
                WriteLine("No questions found in the database");
                ReadKey();
                return;
            }

            // Select 10 random questions for current round
            var quizQuestions = questions.OrderBy(q => random.Next()).Take(10).ToList();

            // Run the quiz and calculate the score
            int score = PlayQuiz(quizQuestions);

            // Show the final score and ask if user wants to play again
            ShowResults(score, quizQuestions.Count);
            AskToPlayAgain();
        }

        // Method to load all questions and filter by category if needed
        private List<Models.Question> LoadQuestions(string category)
        {
            var questions = QuestionRepository.GetAllQuestions();

            if (category != "mixed")
            {
                questions = questions.Where(q => q.Category.ToLower() == category).ToList();
            }

            return questions;
        }

        // Method to loop through the selected questions and present them to user
        private int PlayQuiz(List<Models.Question> questions)
        {
            int score = 0;

            foreach (var q in questions)
            {
                Clear();
                WriteLine($"[Category: {q.Category}]");
                WriteLine($"\n{q.Text}\n");

                for (int i = 0; i < q.Options.Length; i++)
                    WriteLine($"  {i + 1}. {q.Options[i]}");

                int answer = GetAnswer(q.Options.Length);

                if (answer == q.CorrectOption)
                {
                    WriteLine("\nCorrect!");
                    score++;
                }
                else
                {
                    WriteLine($"\nWrong, the correct answer was: {q.Options[q.CorrectOption - 1]}");
                }

                Write("\nPress any key to continue");
                ReadKey();
            }

            return score;
        }

        // Method to read and validate user input
        private int GetAnswer(int numberOfOptions)
        {
            Write("\nYour answer: ");
            int answer;

            while (!int.TryParse(ReadLine(), out answer) || answer < 1 || answer > numberOfOptions)
            {
                Write("Invalid input, try again: ");
            }

            return answer;

        }

        // Method to display final score with simulated animation
        private void ShowResults(int score, int total)
        {
            WriteLine("\n\nQuiz finished! Calculating your results ");
            for (int i = 0; i < 12; i++)
            {
                Write(".");
                Thread.Sleep(380);
            }
            Clear();
            WriteLine($"You scored: {score}/{total}\n");
        }

        // Method to ask if user wants to play again (restart quiz or return to menu)
        private void AskToPlayAgain()
        {
            while (true)
            {
                Write("\nDo you want to play again? (y/n): ");
                string input = ReadLine()!.Trim().ToLower();

                if (input == "y")
                {
                    new GameMenu().ShowGameMenu();
                    break;
                }
                else if (input == "n")
                {
                    WriteLine("\nReturning to menu ");
                    for (int i = 0; i < 7; i++)
                    {
                        Write(".");
                        Thread.Sleep(350);
                    }
                    Clear();
                    break;
                }
                else
                {
                    WriteLine("Invalid input. Please type 'y' or 'n'.");
                }
            }
        }
    }
}