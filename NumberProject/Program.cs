using GameLibrary;
using ConsoleLibrary;
using System;

namespace NumberProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration configuration = new Configuration();
            UserConsole userConsole = new UserConsole(configuration.MinNumberValue, configuration.MaxNumberValue, configuration.IsDefault);
            Game game = new Game(configuration.MinNumberValue, configuration.MaxNumberValue);

            do
            {
                PlayGame();
            } while (userConsole.IsGameRestart());

            void PlayGame()
            {
                game.StartNew();

                CompareResult compare = game.CompareWithAnswer(userConsole.GetUserAnswer());

                while (compare != CompareResult.AnswerIsEqually)
                {
                    userConsole.AskAnotherNumber(ConvertCompareToMessage(compare));

                    compare = game.CompareWithAnswer(userConsole.GetUserAnswer());
                }

                userConsole.Congratulations(game.AttemptsToGuess);
            }

            Messages ConvertCompareToMessage(CompareResult compare)
            {
                try
                {
                    return (Messages)Enum.Parse(typeof(Messages), compare.ToString(), true);
                }
                catch
                {
                    return Messages.MessageLost;
                }
            }
        }
    }
}
