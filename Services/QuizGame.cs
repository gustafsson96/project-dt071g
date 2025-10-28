using QuizApp.Data;
using QuizApp.Menus;
using static System.Console;
using System.Threading;

namespace QuizApp.Services
{
    // Handles the main quiz logic
    public class QuizGame
    {
        private readonly Random random = new Random();

        // Starts the quiz for a selected category
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

            // Select 10 shuffled questions for current quiz round
            var quizQuestions = questions.OrderBy(q => random.Next()).Take(10).ToList();

            // Run quiz and calculate score
            int score = PlayQuiz(quizQuestions);

            // Show results and ask if user wants to play again
            ShowResults(score, quizQuestions.Count);
            AskToPlayAgain();
        }

        // Load all questions from database and filter if needed
        private List<Models.Question> LoadQuestions(string category)
        {
            var questions = QuestionRepository.GetAllQuestions();

            // If category is not "mixed", filter by selected category
            if (category != "mixed")
            {
                questions = questions.Where(q => q.Category.ToLower() == category).ToList();
            }

            return questions;
        }

        // Loop through the selected questions and displays them to user one by one
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

                // Check if answer is correct
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

        // Reads and validates the selected answer from the user
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

        // Displays the final score with simulated "Calculating..." animation
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

        // Asks if user wants to play again (restart quiz or return to main menu)
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