using Microsoft.VisualBasic;
using MovieQuiz.Data;
using static System.Console;

namespace MovieQuiz
{
    public class Quiz
    {

        public void StartQuiz()
        {
            var questions = QuestionRepository.GetAllQuestions();

            if (questions.Count == 0)
            {
                WriteLine("No questions found in the database");
                ReadKey();
                return;
            }

            var random = new Random();
            var quizQuestions = questions.OrderBy(q => random.Next()).Take(10).ToList();

            int score = 0;

            foreach (var q in quizQuestions)
            {
                Clear();
                WriteLine($"[Category: {q.Category}]\n");
                WriteLine($"\n{q.Text}\n");

                for (int i = 0; i < q.Options.Length; i++)
                {
                    WriteLine($"  {i + 1}. {q.Options[i]}");
                }

                Write("\nYour answer: ");
                int answer;
                while (!int.TryParse(ReadLine(), out answer) || answer < 1 || answer > q.Options.Length)
                {
                    Write("Invalid input, try again: ");
                }

                if (answer == q.CorrectOption)
                {
                    WriteLine("Correct!");
                    score++;
                }
                else
                {
                    WriteLine($"Wrong, the correct answer was: {q.Options[q.CorrectOption - 1]}");
                }

                WriteLine("\nPress any key for the next question...");
                ReadKey();


            }
            Clear();
            WriteLine($"Quiz finished! Your score: {score}/{quizQuestions.Count}");
            WriteLine("Press any key to return to the menu...");
            ReadKey();
        }
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