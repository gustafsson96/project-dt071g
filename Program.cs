using static System.Console;
using QuizApp.Data;
using QuizApp.Menus;
using QuizApp.Utilities;

namespace QuizApp
{
    public class Program
    {
        public static void Main()
        {
            // Initialize database
            DatabaseConnection.InitializeDatabase();

            // Show ASCII art when program starts
            AsciiArt art = new AsciiArt();
            art.collectArt();

            // Show the menu
            MainMenu mainMenu = new MainMenu();
            mainMenu.ShowMainMenu();
        }
    }
}