// Game Menu

using static System.Console;

namespace QuizApp
{
    public class GameMenu
    {
        bool running = true;

        public void ShowGameMenu()
        {
            // Show menu with alternatives
            while (running)
            {
                WriteLine("\nPICK A CATEGORY: ");
                WriteLine("1. MOVIES");
                WriteLine("2. MUSIC");
                WriteLine("3. GENERAL KNOWLEDGE");
                WriteLine("4. MIXED");
                Write("\nChoose an option: \n");
                 Write("\nPress 'q' to go back");
                string choice = ReadLine()!;

                switch (choice.ToLower())
                {
                    // Start the quiz
                    case "1":
                        running = false;
                        break;
                    case "2":
                        running = false;
                        break;
                    case "3":
                        running = false;
                        break;
                    case "4":
                        Quiz quiz = new Quiz();
                        quiz.StartQuiz();
                        break;
                    // Exit
                    case "q":
                        running = false;
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