using static System.Console;
using QuizApp.Services;
using QuizApp.Security;

namespace QuizApp.Menus
{
    // Handles the options for developer-only functionality
    public class DeveloperMenu
    {
        QuizServices quizServices = new QuizServices();
        DeveloperAccess access = new DeveloperAccess();

        // Displays the developer menu if access is granted after password check
        public void ShowDeveloperMenu()
        {
            if (!access.RequestAccess()) return;

            bool running = true;

            while (running)
            {
                // Menu alternatives
                Clear();
                WriteLine("\nDEVELOPER MENU\n");
                WriteLine("1. Show all questions");
                WriteLine("2. Add a new question");
                WriteLine("3. Delete a question");
                Write("\nPress 'q' to go back\n");
                Write("\nChoose an option: ");
                string choice = ReadLine()!;

                switch (choice.ToLower())
                {
                    // Show all questions
                    case "1":
                        Clear();
                        quizServices.ShowAllQuestions();
                        break;
                    // Add a new question
                    case "2":
                        Clear();
                        quizServices.AddQuestion();
                        break;
                    // Delete a question
                    case "3":
                        Clear();
                        quizServices.DeleteQuestion();
                        break;
                    // Exit to previous menu
                    case "q":
                        running = false;
                        Clear();
                        break;
                    default:
                        WriteLine("\nInvalid option, press any key to try again");
                        ReadKey();
                        break;
                }
            }
        }
    }
}