using static System.Console;

namespace MovieQuiz
{
    public class Program
    {
        public static void Main()
        {
            var running = true;

            while (running)
            {
                WriteLine("Welcome to my quiz app!");
                DatabaseConnection.InitializeDatabase();

                string input = ReadLine()!;
                if (input.ToLower() == "q") break;
            }

        }
    }
}