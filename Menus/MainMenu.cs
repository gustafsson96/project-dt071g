using static System.Console;
using QuizApp.Utilities;

namespace QuizApp.Menus
{
    // Handles the main menu of the quiz application
    public class MainMenu
    {
        // Shows the main menu and handles user input
        public void ShowMainMenu()
        {
            // Local method to print menu options
            void PrintMenu()
            {
                {
                    WriteLine("\nMENU\n");
                    WriteLine("1. START THE QUIZ");
                    WriteLine("2. INSTRUCTIONS");
                    WriteLine("3. EXIT");
                    WriteLine("\n(For developers: type 'devmode' to manage questions)");
                }
            }

            // Display the menu at first
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
                    // Print instructions
                    case "2":
                        GameInstructions gameInstructions = new GameInstructions();
                        gameInstructions.ShowInstructions();
                        PrintMenu();
                        break;
                    // Exit the application
                    case "3":
                        running = false;
                        break;
                    // Enter developer mode
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
