// DEVELOPER MENU

using static System.Console;
using QuizApp.Services;

namespace QuizApp.Menus
{
    public class DeveloperMenu
    {
        bool running = true;

        public void ShowDeveloperMenu()
        {
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
                        QuizServices quizServices = new QuizServices();
                        quizServices.ShowAllQuestions(); 
                        break;
                    case "2":
                        running = false;
                        WriteLine("\nAdd new question\n");
                        break;
                    case "3":
                        running = false;
                        WriteLine("\nDelete a question\n");
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