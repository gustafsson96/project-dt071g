using static System.Console;
using MovieQuiz.Data;

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