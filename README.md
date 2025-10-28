# Quizapp

## Overview
QuizApp is a console-based quiz applicaiton created using C#.NET with a SQLite database, and it makes up my final project for the course 
"Programmering in C#.NET" at Webbutvecklingsprogrammet, Mittuniversitetet. Users can play the quiz based on categories and developers can manage the questions directly in the program. 

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
Data/DatabaseConnection.cs # Initial database connection
Data/QuestionRepository.cs # CRUD for developers
Menus/MainMenu.cs # Main menu of the program
Menus/GameMenu.cs # Menu to pick what category to play 
Menus/DeveloperMenu.cs # Developer menu
Models/Questions.cs # Questions model
Security/PasswordValidator.cs # Validate developer password
Security/RequestAccess.cs # Prompt for developer password
Services/QuizGame.cs # Quiz logic
Services/QuizService.cs # Developer functionality (view for CRUD actions)
Utilities/AsciiArt.cs # Handles ASCII art presented when program starts
Utilities/asciiart.txt # The actual ASCII art "QUIZ IT UP!"
Utilites/GameInstructions.cs # Game instructions
quiz.db # Database file
Program.cs # Main program file


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
6. Navigate the quiz from the main menu presented in the console. 

## Future improvments 

* Save player names and scores to add leaderboard
* Protect developer view 
* Add more categories and questions
* Implement full CRUD-funtionality by adding the option to update a question via the program

*Created by:* <br>
*Julia Gustafsson* <br>
*HT-2025*