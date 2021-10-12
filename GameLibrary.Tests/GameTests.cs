using Xunit;
using System.Collections.Generic;
using System.Reflection;

namespace GameLibrary.Tests
{
    public class GameTests
    {
        private readonly Game game;
        private readonly int minNumberValue = 0;
        private readonly int maxNumberValue = 1;

        public GameTests()
        {
            game = new Game(minNumberValue, maxNumberValue);
        }

        [Theory]
        [MemberData(nameof(IsAnswerRightTestsData))]
        public void IsAnswerRight_GetsUserAnswers_ReturnsCorrectBooleans(bool expectedReturn, int rightAnswer, int userAnswer, bool isAnswerLess)
        {
            // arrange
            FieldInfo RightAnswer = typeof(Game).GetField("RightAnswer", BindingFlags.NonPublic | BindingFlags.Instance);
            RightAnswer.SetValue(game, rightAnswer);
            int attemptsToGuess = game.AttemptsToGuess;

            // act
            bool isAnswerRight = game.IsAnswerRight(userAnswer);

            // assert
            Assert.Equal(expectedReturn, isAnswerRight);
            if (isAnswerRight)
            {
                Assert.Equal(game.AttemptsToGuess, attemptsToGuess);
            }
            else
            {
                Assert.Equal(isAnswerLess, game.IsAnswerLess);
                Assert.Equal(game.AttemptsToGuess, attemptsToGuess + 1);
            }
        }

        public static IEnumerable<object[]> IsAnswerRightTestsData()
        {
            yield return new object[] { true, 1, 1, default };
            yield return new object[] { false, 1, 0, false };
            yield return new object[] { false, 0, 1, true };
        }
    }
}
