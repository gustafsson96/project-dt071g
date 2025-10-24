// MAIN MENU

using System.Text;
using static System.Console;
using QuizApp.Services;

namespace QuizApp.Menus
{
    public class MainMenu
    {
        bool running = true;

        public void ShowMainMenu()
        {
            // Show menu with alternatives
            while (running)
            {
                WriteLine("\nMenu: ");
                WriteLine("1. START THE QUIZ");
                WriteLine("2. EXIT");
                WriteLine("(Type 'developer mode' to add questions)");
                Write("\nChoose an option: ");
                string choice = ReadLine()!;

                switch (choice.ToLower())
                {
                    // Start the quiz
                    case "1":
                        GameMenu gameMenu = new GameMenu();
                        gameMenu.ShowGameMenu();
                        break;
                    // Exit
                    case "2":
                        running = false;
                        break;
                    // Enter developer mode (FOR DEVELOPERS ONLY)
                    case "developer mode":
                        DeveloperMenu developerMenu = new DeveloperMenu();
                        developerMenu.ShowDeveloperMenu();
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