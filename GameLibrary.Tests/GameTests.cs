using Moq;
using Xunit;
using ConsoleLibrary;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Tests
{
    public class GameTests
    {
        [Theory]
        [MemberData(nameof(PlayTestsData))]
        public void Play_GetUserAnswers_LastAnswerIsRight(int[] userAnswers)
        {
            // arrange
            var userConsole = new Mock<IUserConsole>();
            int index = 0;
            userConsole.Setup(x => x.GetUserAnswer())
                .Returns(() => userAnswers[index])
                .Callback(() => index++);

            // act
            var game = new Game(userConsole.Object);
            game.Play(userAnswers.Last());

            // assert
            userConsole.Verify(x => x.GetUserAnswer(), Times.Exactly(userAnswers.Length));
            userConsole.Verify(x => x.AskAnotherNumber(It.IsAny<bool>()), Times.Exactly(userAnswers.Length - 1));
            userConsole.Verify(x => x.Congratulations(userAnswers.Length), Times.Exactly(1));
        }

        public static IEnumerable<object[]> PlayTestsData()
        {
            yield return new object[] { new int[] { 1 } };
            yield return new object[] { new int[] { 1, 0 } };
            yield return new object[] { new int[] { -100, 500, 200, 300, 115, 8 } };
        }
    }
}
