using static System.Console;

namespace MovieQuiz
{
    public class Quiz
    {
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