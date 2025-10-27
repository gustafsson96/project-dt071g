using static System.Console;

namespace QuizApp.Utilities
{
    public class GameInstructions
    {
        public void ShowInstructions()
        {
            Clear();
            WriteLine("\nQUIZ INSTRUCTIONS\n");
            WriteLine("1. Select START THE QUIZ from the main menu.");
            WriteLine("2. In the next view, select a category or choose 'mixed' to play a mix of all questions.");
            WriteLine("3. Each question has four options. Type the number of the correct answer.");
            WriteLine("4. Correct or wrong is presented. Click any button for the next question.");
            WriteLine("5. Each round is 10 questions. Your score is shown at the end of the quiz.");
            WriteLine("6. After finishing, you can choose to play again or return to the main menu.");
            WriteLine("\nGood luck and happy quizzing!");
            WriteLine("\nPress any key to return to the main menu");
            ReadKey();
            Clear();
        }
    }
}