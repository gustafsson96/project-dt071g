using static System.Console;

namespace QuizApp.Services
{
    // Provides CRUD functionality for quiz questions via the developer menu
    public class QuizServices
    {
        // Display all questions currently stored in the databse
        public void ShowAllQuestions()
        {
            // Fetch all questions from the database
            var questions = Data.QuestionRepository.GetAllQuestions();
            WriteLine($"Loaded {questions.Count} questions:\n");

            // Loop through each question to display its details
            foreach (var q in questions)
            {
                WriteLine($"[{q.Category}] {q.Text}");
                for (int i = 0; i < q.Options.Length; i++)
                {
                    WriteLine($"  {i + 1}. {q.Options[i]}");
                }
                WriteLine($"(Correct: {q.CorrectOption})\n");
            }

            WriteLine("Press any key to return to the menu");
            ReadKey();
        }

        // Adds a new question to the database
        public void AddQuestion()
        {
            Clear();
            WriteLine("ADD A NEW QUESTION\n");

            // Prompt for category input
            Write("\nEnter category: ");
            string category = ReadLine()!;
            while (string.IsNullOrWhiteSpace(category))
            {
                Write("Category cannot be empty. Please enter again: ");
                category = ReadLine()!;
            }

            // Prompt for question text
            Write("\nEnter question text: ");
            string questionText = ReadLine()!;
            while (string.IsNullOrWhiteSpace(questionText))
            {
                Write("Question text cannot be empty. Please enter again: ");
                questionText = ReadLine()!;
            }


            // Prompt for 4 answer options and store them in an array
            var options = new string[4];
            for (int i = 0; i < 4; i++)
            {
                Write($"Enter option {i + 1}: ");
                options[i] = ReadLine()!;
                while (string.IsNullOrWhiteSpace(options[i]))
                {
                    Write($"Option {i + 1} cannot be empty. Please enter again: ");
                    options[i] = ReadLine()!;
                }
            }

            
            // Prompt for the number of the correct option
            int correctOption;
            while (true)
            {
                Write("Enter the number of the correct option (1-4): ");
                if (int.TryParse(ReadLine(), out correctOption) && correctOption >= 1 && correctOption <= 4)
                    break;
                WriteLine("Invalid input, please enter 1, 2, 3, or 4.");
            }

            // Create a new Question object with inserted input
            var question = new Models.Question
            {
                Category = category,
                Text = questionText,
                Options = options,
                CorrectOption = correctOption
            };

            // Insert the new question into the database
            Data.QuestionRepository.InsertQuestion(question);

            WriteLine("\nPress any key to return to the menu");
            ReadKey();
        }

        // Delete an existing question from the database
        public void DeleteQuestion()
        {
            // Fetch all questions
            var questions = Data.QuestionRepository.GetAllQuestions();

            if (questions.Count == 0)
            {
                WriteLine("No questions to delete");
                ReadKey();
                return;
            }

            Clear();
            WriteLine("DELETE A QUESTION\n");

            // List questions with their IDs
            foreach (var q in questions)
            {
                WriteLine($"{q.Id}. [{q.Category}] {q.Text}");
            }

            // Prompt for the ID of the question to delete
            int idToDelete;
            while (true)
            {
                Write("\nEnter the ID of the question you want to delete: ");
                if (int.TryParse(ReadLine(), out idToDelete))
                {
                    break;
                }

                Write("Invalid input. Please enter a number");
            }

            // Delete the question from the database
            Data.QuestionRepository.DeleteQuestion(idToDelete);

            WriteLine("\nPress any key to return to the menu");
            ReadKey();
        }
    }
}