using Xunit;
using System.Collections.Generic;
using System.Reflection;

namespace GameLibrary.Tests
{
    public class GameTests
    {
        private readonly Game _sut;
        private readonly int _minNumberValue = 0;
        private readonly int _maxNumberValue = 101;

        public GameTests()
        {
            _sut = new Game(_minNumberValue, _maxNumberValue);
        }

        [Theory]
        [MemberData(nameof(CompareWithAnswerTestsData))]
        public void CompareWithAnswer_VariousUserAnswers_ReturnsCorrectEnum(CompareResult expected, int rightAnswer, int userAnswer)
        {
            // arrange
            FieldInfo answer = typeof(Game).GetField("_answer", BindingFlags.NonPublic | BindingFlags.Instance);
            answer.SetValue(_sut, rightAnswer);
            int attemptsToGuess = _sut.AttemptsToGuess;

            // act
            CompareResult resultOfCompare = _sut.CompareWithAnswer(userAnswer);

            // assert
            Assert.Equal(expected, resultOfCompare);
            if (expected == CompareResult.AnswerIsEqually)
            {
                Assert.Equal(_sut.AttemptsToGuess, attemptsToGuess);
            }
            else
            {
                Assert.Equal(_sut.AttemptsToGuess, attemptsToGuess + 1);
            }
        }

        public static IEnumerable<object[]> CompareWithAnswerTestsData()
        {
            yield return new object[] { CompareResult.AnswerIsEqually, 0, 0 };
            yield return new object[] { CompareResult.AnswerIsMore, 1, 0 };
            yield return new object[] { CompareResult.AnswerIsLess, 1, 2 };
            yield return new object[] { CompareResult.AnswerIsMuchHigher, 101, 0 };
            yield return new object[] { CompareResult.AnswerIsMuchLower, 0, 101 };
        }
    }
}
