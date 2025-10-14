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
                Clear();
                WriteLine("**** QUIZ ****");
                WriteLine("\nMenu: ");
                WriteLine("1. Option 1");
                WriteLine("2. Option 2");
                WriteLine("3. Option 3");
                WriteLine("4. Exit");
                Write("\nChoose an option: ");
                string choice = ReadLine()!;

                switch (choice)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4": running = false; break;
                    default:
                        WriteLine("\nInvalid option, press any key to try again");
                        ReadKey();
                        break;
                }
            }
        }
    }
}