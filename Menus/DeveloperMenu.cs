// DEVELOPER MENU

using static System.Console;
using QuizApp.Services;
using QuizApp.Security;

namespace QuizApp.Menus
{
    public class DeveloperMenu
    {
        QuizServices quizServices = new QuizServices();
        DeveloperAccess access = new DeveloperAccess();
        public void ShowDeveloperMenu()
        {
            if (!access.RequestAccess()) return; // Make sure access is granted via DeveloperAcess method

            bool running = true;
            // Show menu with alternatives
            while (running)
            {
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
                    case "1":
                        Clear();
                        quizServices.ShowAllQuestions();
                        break;
                    case "2":
                        Clear();
                        quizServices.AddQuestion();
                        break;
                    case "3":
                        Clear();
                        quizServices.DeleteQuestion();
                        break;
                    // Exit
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