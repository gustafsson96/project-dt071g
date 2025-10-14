namespace MovieQuiz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Text { get; set; }
        public string[] Options { get; set; }
        public int CorrectOption { get; set; }
    }
}