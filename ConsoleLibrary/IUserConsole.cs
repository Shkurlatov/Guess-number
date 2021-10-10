
namespace ConsoleLibrary
{
    public interface IUserConsole
    {
        public int MinNumberValue { get; }
        public int MaxNumberValue { get; }

        public int GetUserAnswer();

        public void AskAnotherNumber(bool isAnswerSmaller);

        public void Congratulations(int attemptsToGuess);

        public bool IsGameRestart();
    }
}
