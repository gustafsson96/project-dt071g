# Quizapp

## Overview
QuizApp is a console-based quiz applicaiton created using C#.NET with a SQLite database, and it makes up my final project for the course 
"Programmering in C#.NET" at Webbutvecklingsprogrammet, Mittuniversitetet. Users can play the quiz based on category and developers can manage the questions directly in the program. 

## Features

### For players
* Play a quiz round with 10 random questions based on category, or mixed from all categories. 
* View instructions.
* See if an answer is correct or wrong after each question. 
* Present total score after a finished round. 

### For developers
* Show all questions.
* Add a new question.
* Delete a question based on ID.
* View protected by a developer password.

## Project structure
Data/DatabaseConnection.cs # Initial database connection <br>
Data/QuestionRepository.cs # CRUD for developers <br>
Menus/MainMenu.cs # Main menu of the program <br>
Menus/GameMenu.cs # Menu to pick what category to play <br>
Menus/DeveloperMenu.cs # Developer menu <br>
Models/Questions.cs # Questions model <br>
Security/PasswordValidator.cs # Validate developer password <br>
Security/RequestAccess.cs # Prompt for developer password <br>
Services/QuizGame.cs # Quiz logic <br>
Services/QuizService.cs # Developer functionality (view for CRUD actions) <br>
Utilities/AsciiArt.cs # Handles ASCII art presented when program starts <br>
Utilities/asciiart.txt # The actual ASCII art "QUIZ IT UP!" <br>
Utilites/GameInstructions.cs # Game instructions <br>
quiz.db # Database file <br>
Program.cs # Main program file <br>


## Technologies used
* **Language used:** C#
* **.NET Framework:** Version 9.0.304
* **Database:** SQLite
* **Other packages:** Microsoft.Data.Sqlite (NuGet)
* **IDE:** Visual Studio Code

## How to run
1. Ensure the following prerequisites are installed:
* .NET SDK
* Visual Studio Code with the C# exstension (to use the same environment as me) OR
* You can run the program directly from the terminal using dotnet run
2. Clone the repository: git clone https://github.com/gustafsson96/project-dt071g.git or download the ZIP and extract it
3. Open the project in Visual Studio Code or in the terminal
4. Make sure the quiz.db file is located in the project root (same level as Program.cs)
5. Run the application with the command: dotnet run
6. Navigate the quiz from the main menu presented in the console

## Future improvments 

* Save player names and scores to add leaderboard
* Better protection of developer view 
* Add more categories and questions
* Implement full CRUD-funtionality by adding the option to update a question via the program

*Created by:* <br>
*Julia Gustafsson* <br>
*HT-2025*