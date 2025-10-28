using static System.Console;
using QuizApp.Services;

namespace QuizApp.Menus
{
    // Handles the menu to start the quiz
    public class GameMenu
    {
        bool running = true;

        // Displays the category menu and starts the quiz based on user selection
        public void ShowGameMenu()
        {
            while (running)
            {
                // Game alternatives
                Clear();
                WriteLine("\nPICK A CATEGORY\n");
                WriteLine("1. MOVIES");
                WriteLine("2. MUSIC");
                WriteLine("3. GENERAL KNOWLEDGE");
                WriteLine("4. MIXED");
                Write("\nPress 'q' to go back\n");
                Write("\nChoose an option: ");
                string choice = ReadLine()!;

                switch (choice.ToLower())
                {
                    // Movie category
                    case "1":
                        running = false;
                        new QuizGame().StartQuiz("movies");
                        break;
                    // Music category
                    case "2":
                        running = false;
                        new QuizGame().StartQuiz("music");
                        break;
                    // General knowledge category
                    case "3":
                        running = false;
                        new QuizGame().StartQuiz("general knowledge");
                        break;
                    // Questions mixed from all categories
                    case "4":
                        running = false;
                        new QuizGame().StartQuiz("mixed");
                        break;
                    // Exit and return to main menu
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