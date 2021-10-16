using System;

namespace ConsoleLibrary
{
    public class UserConsole
    {
        private readonly int _minNumberValue;
        private readonly int _maxNumberValue;

        public UserConsole(int minNumberValue, int maxNumberValue, bool isDefault)
        {
            _minNumberValue = minNumberValue;
            _maxNumberValue = maxNumberValue;

            if (isDefault)
            {
                Console.WriteLine(Messages.SettingsLost.GetDescription());
            }

            Console.WriteLine(String.Format(Messages.GreetingsAndStart.GetDescription(), _minNumberValue, _maxNumberValue));
        }

        public int GetUserAnswer()
        {
            return AcceptableInput(_minNumberValue, _maxNumberValue);
        }

        public void AskAnotherNumber(Messages message)
        {
            Console.WriteLine(message.GetDescription());
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
                Console.WriteLine(String.Format(Messages.StartNewGame.GetDescription(), _minNumberValue, _maxNumberValue));

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
