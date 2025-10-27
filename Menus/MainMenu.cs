// MAIN MENU

using System.Text;
using static System.Console;
using QuizApp.Services;

namespace QuizApp.Menus
{
    public class MainMenu
    {
        public void ShowMainMenu()
        {
            // Local method to print menu alternatives
            void PrintMenu()
            {
                {
                    WriteLine("\nMENU\n");
                    WriteLine("1. START THE QUIZ");
                    WriteLine("2. EXIT");
                    WriteLine("\n(For developers: type 'devmode' to manage questions)");
                }
            }

            PrintMenu();


            bool running = true;
            while (running)
            {
                Write("\nChoose an option: ");
                string choice = ReadLine()!;

                switch (choice.ToLower())
                {
                    // Start the quiz
                    case "1":
                        GameMenu gameMenu = new GameMenu();
                        gameMenu.ShowGameMenu();
                        PrintMenu();
                        break;
                    // Exit
                    case "2":
                        running = false;
                        break;
                    // Enter developer mode (FOR DEVELOPERS ONLY)
                    case "devmode":
                        DeveloperMenu developerMenu = new DeveloperMenu();
                        developerMenu.ShowDeveloperMenu();
                        PrintMenu();
                        break;
                    default:
                        WriteLine("\nInvalid option, please try again");
                        break;
                }
            }
        }
    }
}
