using System.Security.Cryptography;
using GameLibrary;
using ConsoleLibrary;

namespace NumberProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int minAnswerValue = 0;
            int maxAnswerValue = 100;

            Game game = new Game(new UserConsole(minAnswerValue, maxAnswerValue));

            do
            {
                game.Play(rightAnswer: RandomNumberGenerator.GetInt32(minAnswerValue, maxAnswerValue + 1));
            } while (game.IsRestart());
        }
    }
}
