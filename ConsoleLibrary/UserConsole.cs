using System;

namespace ConsoleLibrary
{
    public class UserConsole: IUserConsole
    {
        public int MinNumberValue { get; }
        public int MaxNumberValue { get; }

        public UserConsole(int minNumberValue, int maxNumberValue)
        {
            MinNumberValue = minNumberValue;
            MaxNumberValue = maxNumberValue;

            Console.WriteLine(String.Format("Hello! I thought a number from {0} to {1}. Try to guess.", MinNumberValue, MaxNumberValue));
        }

        public int GetUserAnswer()
        {
            return AcceptableInput(MinNumberValue, MaxNumberValue);
        }

        public void AskAnotherNumber(bool isAnswerSmaller)
        {
            if (isAnswerSmaller)
            {
                Console.WriteLine("\nMy number is less. Please try again.");
            }
            else
            {
                Console.WriteLine("\nMy number is more. Please try again.");
            }
        }

        public void Congratulations(int attemptsToGuess)
        {
            Console.WriteLine(String.Format("\nCongratulations, you guessed the number on try #{0}.", attemptsToGuess));
        }

        public bool IsGameRestart()
        {
            Console.WriteLine("\nPlease enter 1 if you want to start a new game or 0 if you not.");

            if (AcceptableInput(0, 1) == 1)
            {
                Console.Clear();
                Console.WriteLine(String.Format("Well, I thought another number from {0} to {1}. Try to guess.", MinNumberValue, MaxNumberValue));

                return true;
            }

            return false;
        }

        public int AcceptableInput(int minValue, int maxValue)
        {
            bool isAcceptableInput = int.TryParse(Console.ReadLine(), out int inputValue);

            while (!isAcceptableInput || inputValue < minValue || inputValue > maxValue)
            {
                Console.WriteLine(String.Format("\nPlease enter an intager from {0} to {1}.", minValue, maxValue));

                isAcceptableInput = int.TryParse(Console.ReadLine(), out inputValue);
            }

            return inputValue;
        }
    }
}
