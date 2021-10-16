using System.Security.Cryptography;

namespace GameLibrary
{
    public class Game
    {
        public int AttemptsToGuess { get; private set; }

        private readonly int _minNumberValue;
        private readonly int _maxNumberValue;
        private int _answer;

        public Game(int minNumberValue, int maxNumberValue)
        {
            _minNumberValue = minNumberValue;
            _maxNumberValue = maxNumberValue;
        }

        public void StartNew()
        {
            _answer = RandomNumberGenerator.GetInt32(_minNumberValue, _maxNumberValue + 1);
            AttemptsToGuess = 1;
        }

        public CompareResult CompareWithAnswer(int userNumber)
        {
            int difference = _answer - userNumber;

            if (difference != 0)
            {
                AttemptsToGuess++;

                if (difference < 0)
                {
                    if (difference < -100)
                    {

                        return CompareResult.AnswerIsMuchLower;
                    }

                    return CompareResult.AnswerIsLess;
                }
                else
                {
                    if (difference > 100)
                    {

                        return CompareResult.AnswerIsMuchHigher;
                    }

                    return CompareResult.AnswerIsMore;
                }
            }

            return CompareResult.AnswerIsEqually;
        }
    }
}
