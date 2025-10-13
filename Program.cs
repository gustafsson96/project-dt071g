using static System.Console;

namespace quizApp
{
    public class Program
    {
        public static void Main()
        {
            WriteLine("Welcome to my quiz app!");
            databaseConnection.InitializeDatabase();
        }
    }
}