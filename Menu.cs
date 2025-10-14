// Classes for the menu

using static System.Console;

namespace MovieQuiz
{
    public class Menu
    {
        bool running = true;

        public void ShowMenu()
        {
            while (running)
            {
                WriteLine("**** QUIZ ****");
                WriteLine("\nMenu: ");
                WriteLine("1. START THE QUIZ");
                WriteLine("2. Exit");
                WriteLine("(Type 'developer mode' to add questions)");
                Write("\nChoose an option: ");
                string choice = ReadLine()!;

                switch (choice.ToLower())
                {
                    case "1": WriteLine("You started the program!"); break;
                    case "2": running = false; break;
                    case "developer mode": running = false; DeveloperMode.DevMessage(); break;
                    default:
                        WriteLine("\nInvalid option, press any key to try again");
                        ReadKey();
                        break;
                }
            }
        }
    }
}