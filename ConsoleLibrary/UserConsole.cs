using System;

namespace ConsoleLibrary
{
    public class UserConsole
    {
        public int MinNumberValue { get; }
        public int MaxNumberValue { get; }

        public UserConsole(int minNumberValue, int maxNumberValue)
        {
            MinNumberValue = minNumberValue;
            MaxNumberValue = maxNumberValue;

            Console.WriteLine(String.Format(Messages.GreetingsAndStart.GetDescription(), MinNumberValue, MaxNumberValue));
        }

        public int GetUserAnswer()
        {
            return AcceptableInput(MinNumberValue, MaxNumberValue);
        }

        public void AskAnotherNumber(bool isAnswerSmaller)
        {
            if (isAnswerSmaller)
            {
                Console.WriteLine(Messages.NumberIsLess.GetDescription());
            }
            else
            {
                Console.WriteLine(Messages.NumberIsMore.GetDescription());
            }
        }

        public void Congratulations(int attemptsToGuess)
        {
            Console.WriteLine(String.Format(Messages.Congratulations.GetDescription(), attemptsToGuess));
        }

        public bool IsGameRestart()
        {
            Console.WriteLine(Messages.RestartOrNot.GetDescription());

            if (AcceptableInput(0, 1) == 1)
            {
                Console.Clear();
                Console.WriteLine(String.Format(Messages.StartNewGame.GetDescription(), MinNumberValue, MaxNumberValue));

                return true;
            }

            return false;
        }

        private int AcceptableInput(int minValue, int maxValue)
        {
            bool isAcceptableInput = int.TryParse(Console.ReadLine(), out int inputValue);

            while (!isAcceptableInput || inputValue < minValue || inputValue > maxValue)
            {
                Console.WriteLine(String.Format(Messages.InputIsIncorrect.GetDescription(), minValue, maxValue));

                isAcceptableInput = int.TryParse(Console.ReadLine(), out inputValue);
            }

            return inputValue;
        }
    }
}
