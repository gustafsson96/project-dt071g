// CRUD ACTIONS FOR DEVELOPERS

using static System.Console;

namespace QuizApp.Services
{
    public class QuizServices
    {
        // Show all questions
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

        public void AddQuestion()
        {
            Clear();
            WriteLine("ADD A NEW QUESTION\n");

            // Prompt for user input to add new question
            Write("\nEnter category: ");
            string category = ReadLine()!;

            Write("\nEnter question text: ");
            string questionText = ReadLine()!;

            // Create an array to store the four answer options
            var options = new string[4];
            for (int i = 0; i < 4; i++)
            {
                Write($"Enter option {i + 1}: ");
                options[i] = ReadLine()!;
            }

            // Ask for correct option
            int correctOption;
            while(true)
            {
                Write("Enter the number of the correct option (1-4): ");
                if (int.TryParse(ReadLine(), out correctOption) && correctOption >= 1 && correctOption <= 4)
            break;
                    WriteLine("Invalid input, please enter 1, 2, 3, or 4.");
            }

            // Create a new Question object with the inserted data
            var question = new Models.Question
            {
                Category = category, 
                Text = questionText,
                Options = options, 
                CorrectOption = correctOption
            };

            // Insert the new question into the database using the InsertQuestion method
            Data.QuestionRepository.InsertQuestion(question);

            WriteLine("\nPress any key to return to the menu");
            ReadKey();
        }

        public void DeleteQuestion()
        {

        }
    }


}