using static System.Console;
using System.Threading;
using System.IO;

namespace QuizApp.Utilities
{
    // Handles displaying ASCII art from a text file with a typewriter effect
    public class AsciiArt
    {
        // Reads the ASCII art from a file and prints it character by character
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