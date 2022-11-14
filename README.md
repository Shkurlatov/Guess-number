# Guess number

The repository contains my work on self-completion of a study Task 
while taking specialized online courses for training C# developers.

An experienced Mentor checked the result and made his remarks on 
the quality of the work performed. The Task could not be completed 
until the Mentor decided that the result was up to industry standards.

The commit called “First implementation of the Task” is my original 
implementation, without any hints. All subsequent commits (if any) 
are the results of my attempts to solve Mentor's remarks and his 
suggestions for improvement the work.

According to the conditions of the school, the Mentor does not provide 
ways to solve shortcomings and sources of information. The search for 
the necessary educational information was carried out independently.
<br/><br/>

## Task Conditions

Application generates an integer number in a given range.
<br/><br/>
User enters a number, trying to guess the computer's number.
<br/><br/>
If the user enters not a number - the result will be an error and ask to enter again.
<br/><br/>
If the user enters a number bigger/smaller - the result will be advice for the user "My number is bigger/smaller" and ask to enter again.
<br/><br/>
If the user guessed the number - congratulate them and ask to play again.
<br/><br/>

## Solution Structure

📁Console<br/>
┣ 📁ConsoleLibrary<br/>
┃ &nbsp;┣ 📄Messages.cs<br/>
┃ &nbsp;┗ 📄UserConsole.cs<br/>
┗ 📁ConsoleLibrary.Tests<br/>
&nbsp; &nbsp; ┗ 📄UserConsoleTests.cs<br/>
📁Game<br/>
┣ 📁GameLibrary<br/>
┃ &nbsp;┣ 📄CompareResult.cs<br/>
┃ &nbsp;┗ 📄Game.cs<br/>
┗ 📁GameLibrary.Tests<br/>
&nbsp; &nbsp; ┗ 📄GameTests.cs<br/>
__📁NumberProject__<br/>
&nbsp;┣ 📄appsettings.json<br/>
&nbsp;┣ 📄Configuration.cs<br/>
&nbsp;┗ 📄Program.cs
<br/><br/>

## Prerequisites

Microsoft Visual Studio 2019 or newer

* Workloads<br/>
    * ASP.NET and web development

- Individual components<br/>
    - .NET Core 3.1 Runtime (LTS) 
<br/><br/>

## Getting Started

Clone the remote repository on your local machine.<br/>
`$ git clone https://github.com/Shkurlatov/Guess-number.git`
<br/><br/>
Go to the project directory.<br/>
`$ cd Guess-number`
<br/><br/>
Open project solution in Microsoft Visual Studio.<br/>
`$ start Task4.sln`
<br/><br/>
Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the application.
<br/><br/>
Use the application following directions in console window. 
<br/><br/>
Press <kbd>Ctrl</kbd>+<kbd>R</kbd>,<kbd>A</kbd> to run tests.
<br/><br/>


## Usage Example
<br/>
<pre>
Hello! I thought a number from 0 to 800. Try to guess.
400
My number is much lower. Please try again.
150
My number is more. Please try again.
200
My number is less. Please try again.
175
My number is less. Please try again.
162
My number is more. Please try again.
169
My number is less. Please try again.
165
My number is less. Please try again.
164

Congratulations, you guessed the number on try #8.

Please enter 1 if you want to start a new game or 0 if you not.
0

Press any key to close this window . . .
</pre>
