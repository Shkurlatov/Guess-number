using GameLibrary;
using ConsoleLibrary;

namespace NumberProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int minNumberValue = 0;
            int maxNumberValue = 100;

            UserConsole userConsole = new UserConsole(minNumberValue, maxNumberValue);
            Game game = new Game(minNumberValue, maxNumberValue);

            do
            {
                PlayGame();
            } while (userConsole.IsGameRestart());

            void PlayGame()
            {
                game.StartNew();

                while (!game.IsAnswerRight(userConsole.GetUserAnswer()))
                {
                    userConsole.AskAnotherNumber(game.IsAnswerLess);
                }

                userConsole.Congratulations(game.AttemptsToGuess);
            }
        }
    }
}
