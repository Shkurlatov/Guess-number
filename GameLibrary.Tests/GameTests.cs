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
        [MemberData(nameof(CompareWithAnswerTestsData))]
        public void CompareWithAnswer_VariousUserAnswers_ReturnsCorrectEnum(AnswerIs expected, int rightAnswer, int userAnswer)
        {
            // arrange
            FieldInfo Answer = typeof(Game).GetField("Answer", BindingFlags.NonPublic | BindingFlags.Instance);
            Answer.SetValue(game, rightAnswer);
            int attemptsToGuess = game.AttemptsToGuess;

            // act
            AnswerIs resultOfCompare = game.CompareWithAnswer(userAnswer);

            // assert
            Assert.Equal(expected, resultOfCompare);
            if (expected == AnswerIs.Equally)
            {
                Assert.Equal(game.AttemptsToGuess, attemptsToGuess);
            }
            else
            {
                Assert.Equal(game.AttemptsToGuess, attemptsToGuess + 1);
            }
        }

        public static IEnumerable<object[]> CompareWithAnswerTestsData()
        {
            yield return new object[] { AnswerIs.Equally, 1, 1 };
            yield return new object[] { AnswerIs.More, 1, 0 };
            yield return new object[] { AnswerIs.Less, 0, 1 };
        }
    }
}
