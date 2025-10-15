using static System.Console;
using System.Threading;

namespace MovieQuiz
{
    public class AsciiArt
    {
        public void collectArt()
        {
            string quizArt = File.ReadAllText("asciiart.txt");

            foreach(var c in quizArt)
            {
                Write(c);
                Thread.Sleep(4);
            }
        }
    }
}