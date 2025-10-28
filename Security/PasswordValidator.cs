namespace QuizApp.Security
{
    // Validates password for developer access
    public static class PasswordValidator
    {
        // Checks if input matches password
        public static bool Validate(string input)
        {
            // Password is hardcoded for demonstrational purposes in this version of the app
            return input == "password123";
        }
    }
}