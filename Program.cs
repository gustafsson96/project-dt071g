using static System.Console;

namespace MovieQuiz
{
    public class Program
    {
        public static void Main()
        {
            DatabaseConnection.InitializeDatabase();

            Menu menu = new Menu();
            menu.ShowMenu();
        }
    }
}