namespace QuizApp.Security
{
    public static class PasswordValidator
    {
        public static bool Validate(string input)
        {
            return input == "password123";
        }
    }
}