using static System.Console;

namespace QuizApp.Security
{
    // Handles access for developer view
    public class DeveloperAccess
    {
        // Prompts the user for a developer password before displaying developer menu
        public bool RequestAccess()
        {
            Clear();
            while (true)
            {
                Write("Insert developer password (or press 'q' to go back): ");
                string input = ReadLine()!;

                // Returns false if user quits and returns to main menu
                if (input.ToLower() == "q") return false;

                // Returns true if password is correct
                if (PasswordValidator.Validate(input)) return true;

                WriteLine("Access denied. Try again.");
            }
        }
    }
}