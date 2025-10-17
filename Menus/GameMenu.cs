// GAME MENU

using static System.Console;
using QuizApp.Services;

namespace QuizApp.Menus
{
    public class GameMenu
    {
        bool running = true;

        public void ShowGameMenu()
        {
            // Show menu with alternatives
            while (running)
            {
                Clear();
                WriteLine("\nPICK A CATEGORY: ");
                WriteLine("1. MOVIES");
                WriteLine("2. MUSIC");
                WriteLine("3. GENERAL KNOWLEDGE");
                WriteLine("4. MIXED");
                Write("\nPress 'q' to go back\n");
                Write("\nChoose an option: ");
                string choice = ReadLine()!;

                switch (choice.ToLower())
                {
                    case "1":
                        running = false;
                        new Quiz().StartQuiz("movies");
                        break;
                    case "2":
                        running = false;
                        new Quiz().StartQuiz("music");
                        break;
                    case "3":
                        running = false;
                        new Quiz().StartQuiz("general knowledge");
                        break;
                    case "4":
                        running = false;
                        new Quiz().StartQuiz("mixed");
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