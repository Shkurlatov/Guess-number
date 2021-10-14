using GameLibrary;
using ConsoleLibrary;

namespace NumberProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration configuration = new Configuration();
            UserConsole userConsole = new UserConsole(configuration.MinNumberValue, configuration.MaxNumberValue);
            Game game = new Game(configuration.MinNumberValue, configuration.MaxNumberValue);

            do
            {
                PlayGame();
            } while (userConsole.IsGameRestart());

            void PlayGame()
            {
                game.StartNew();

                AnswerIs resultOfCompare = game.CompareWithAnswer(userConsole.GetUserAnswer());

                while (resultOfCompare != AnswerIs.Equally)
                {
                    userConsole.AskAnotherNumber(resultOfCompare == AnswerIs.Less);

                    resultOfCompare = game.CompareWithAnswer(userConsole.GetUserAnswer());
                }

                userConsole.Congratulations(game.AttemptsToGuess);
            }
        }
    }
}
