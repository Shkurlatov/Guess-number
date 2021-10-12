using System.Security.Cryptography;

namespace GameLibrary
{
    public class Game
    {
        public int AttemptsToGuess { get; private set; }
        public bool IsAnswerLess { get; private set; }

        private readonly int MinNumberValue;
        private readonly int MaxNumberValue;
        private int RightAnswer;

        public Game(int minNumberValue, int maxNumberValue)
        {
            MinNumberValue = minNumberValue;
            MaxNumberValue = maxNumberValue;
        }

        public void StartNew()
        {
            RightAnswer = RandomNumberGenerator.GetInt32(MinNumberValue, MaxNumberValue + 1);
            AttemptsToGuess = 1;
        }

        public bool IsAnswerRight(int userAnswer)
        {
            if (userAnswer != RightAnswer)
            {
                IsAnswerLess = userAnswer > RightAnswer;
                AttemptsToGuess++;

                return false;
            }

            return true;
        }
    }
}
