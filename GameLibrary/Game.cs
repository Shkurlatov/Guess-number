using System.Security.Cryptography;

namespace GameLibrary
{
    public class Game
    {
        public int AttemptsToGuess { get; private set; }

        private readonly int MinNumberValue;
        private readonly int MaxNumberValue;
        private int Answer;

        public Game(int minNumberValue, int maxNumberValue)
        {
            MinNumberValue = minNumberValue;
            MaxNumberValue = maxNumberValue;
        }

        public void StartNew()
        {
            Answer = RandomNumberGenerator.GetInt32(MinNumberValue, MaxNumberValue + 1);
            AttemptsToGuess = 1;
        }

        public AnswerIs CompareWithAnswer(int userNumber)
        {
            if (userNumber != Answer)
            {
                AttemptsToGuess++;

                if (userNumber > Answer)
                {
                    return AnswerIs.Less;
                }

                return AnswerIs.More;
            }

            return AnswerIs.Equally;
        }
    }

    public enum AnswerIs
    {
        Equally,
        Less,
        More
    }
}
