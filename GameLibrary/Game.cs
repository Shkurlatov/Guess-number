using ConsoleLibrary;

namespace GameLibrary
{
    public class Game
    {
        private readonly IUserConsole userConsole;

        public Game(IUserConsole console)
        {
            userConsole = console;
        }

        public void Play(int rightAnswer)
        {
            int attemptsToGuess = 1;

            int userAnswer = userConsole.GetUserAnswer();

            while (userAnswer != rightAnswer)
            {
                userConsole.AskAnotherNumber(userAnswer > rightAnswer);

                attemptsToGuess++;

                userAnswer = userConsole.GetUserAnswer();
            }

            userConsole.Congratulations(attemptsToGuess);
        }

        public bool IsRestart()
        {
            return userConsole.IsGameRestart();
        }
    }
}
