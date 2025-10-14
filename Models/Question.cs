namespace MovieQuiz.Models
{
    // Represents a single question
    public class Question
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string[] Options { get; set; } = Array.Empty<string>();
        public int CorrectOption { get; set; }
    }
}