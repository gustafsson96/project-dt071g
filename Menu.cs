// Classes for the menu

using System.Text;
using static System.Console;

namespace MovieQuiz
{
    public class Menu
    {
        bool running = true;

        public void ShowMenu()
        {
            // Show menu with alternatives
            while (running)
            {
                AsciiArt art = new AsciiArt();
                art.collectArt();
                WriteLine("\nMenu: ");
                WriteLine("1. START THE QUIZ");
                WriteLine("2. Exit");
                WriteLine("(Type 'developer mode' to add questions)");
                Write("\nChoose an option: ");
                string choice = ReadLine()!;

                switch (choice.ToLower())
                {
                    // Start the quiz
                    case "1":
                        Quiz quiz = new Quiz();
                        quiz.StartQuiz();
                        break;
                    // Exit
                    case "2":
                        running = false;
                        break;
                    // Enter developer mode (FOR DEVELOPERS ONLY)
                    case "developer mode":
                        DeveloperMode.DevMessage();
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