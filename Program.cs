using static System.Console;

namespace quizApp
{
    public class Program
    {
        public static void Main()
        {
            var running = true;

            while (running)
            {
                WriteLine("Welcome to my quiz app!");
                databaseConnection.InitializeDatabase();

                string input = ReadLine()!;
                if (input.ToLower() == "q") break;
            }

        }
    }
}