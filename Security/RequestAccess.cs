using static System.Console;

namespace QuizApp.Security
{
    public class DeveloperAccess
    {
        public bool RequestAccess()
        {
            Clear();
            while (true)
            {
                Write("Insert developer password (or press 'q' to go back): ");
                string input = ReadLine()!;

                if (input.ToLower() == "q") return false;
                if (PasswordValidator.Validate(input)) return true;

                WriteLine("Access denied. Try again.");
            }
        }
    }
}