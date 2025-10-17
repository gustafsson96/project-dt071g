using static System.Console;
using QuizApp.Data;

namespace QuizApp
{
    public class Program
    {
        public static void Main()
        {
            // Initialize database
            DatabaseConnection.InitializeDatabase();

            // Show the menu
            MainMenu mainMenu = new MainMenu();
            mainMenu.ShowMenu();
        }
    }
}