using static System.Console;
using System.Threading;

namespace QuizApp.Utilities
{
    public class AsciiArt
    {
        public void collectArt()
        {
            string quizArt = File.ReadAllText("Utilities/asciiart.txt");

            foreach(var c in quizArt)
            {
                Write(c);
                Thread.Sleep(4);
            }
        }
    }
}