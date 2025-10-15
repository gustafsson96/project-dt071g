using static System.Console;
using System.Threading;

namespace MovieQuiz
{
    public class AsciiArt
    {
        public void collectArt()
        {
            string movieArt = File.ReadAllText("asciiart.txt");

            foreach(var c in movieArt)
            {
                Write(c);
                Thread.Sleep(5);
            }
        }
    }
}