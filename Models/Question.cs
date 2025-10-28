namespace QuizApp.Models
{
    // Represents a single quiz question
    public class Question
    {
        // Unique identifier for the question in the database
        public int Id { get; set; }

        // Category of the question
        public string Category { get; set; } = string.Empty;

        // The text of the question itself
        public string Text { get; set; } = string.Empty;

        // Array of answer alternatives (always 4 in this program)
        public string[] Options { get; set; } = Array.Empty<string>();

        // Index of the correct answer (1-4)
        public int CorrectOption { get; set; }
    }
}