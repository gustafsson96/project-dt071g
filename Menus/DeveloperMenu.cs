// DEVELOPER MENU

using static System.Console;
using QuizApp.Services;

namespace QuizApp.Menus
{
    public class DeveloperMenu
    {
        // Method to simulate a password check to enter developer mode
        public void ValidatePassword() {

            Clear();

            while (true) 
            {
            Write("Insert developer password (or press 'q' to go back): ");
            string passwordInput = ReadLine();

            if (passwordInput.ToLower() == "q") // Give user the option to return to main menu
            {
                Clear();
                return;
            } else if (passwordInput == "password123") // Password created only to demonstrate the idea of a password check
            {
                Clear();
                ShowDeveloperMenu();
                break;
            } else
            {
                Clear();
                WriteLine("Access denied. Try again.\n");
            }
            }
        }



        public void ShowDeveloperMenu()
        {
            bool running = true;

            QuizServices quizServices = new QuizServices();

            // Show menu with alternatives
            while (running)
            {
                Clear();
                WriteLine("\nDEVELOPER MENU\n");
                WriteLine("1. Show all questions");
                WriteLine("2. Add a new question");
                WriteLine("3. Delete a question");
                Write("\nPress 'q' to go back\n");
                Write("\nChoose an option: ");
                string choice = ReadLine()!;

                switch (choice.ToLower())
                {
                    case "1":
                        Clear();
                        quizServices.ShowAllQuestions(); 
                        break;
                    case "2":
                        Clear();
                        quizServices.AddQuestion();
                        break;
                    case "3":
                        Clear();
                        quizServices.DeleteQuestion();
                        break;
                    // Exit
                    case "q":
                        running = false;
                        Clear();
                        break;
                    default:
                        WriteLine("\nInvalid option, press any key to try again");
                        ReadKey();
                        break;
                }
            }
        }
    }
}