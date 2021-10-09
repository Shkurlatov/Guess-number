using Xunit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleLibrary.Tests
{
    public class UserConsoleTests
    {
        private readonly UserConsole userConsole;

        private readonly int MinNumberValue = 0;
        private readonly int MaxNumberValue = 1;

        public UserConsoleTests()
        {
            userConsole = new UserConsole(MinNumberValue, MaxNumberValue);
        }

        [Theory]
        [MemberData(nameof(AcceptableInputTestsData))]
        public void AcceptebleInput_GetInputStrings_LastInputIsAcceptable(string[] userInput)
        {
            // arrange
            Console.SetIn(new StringReader(string.Join('\r', userInput)));

            // act
            int acceptableInput = userConsole.AcceptableInput(MinNumberValue, MaxNumberValue);

            // assert
            Assert.Equal(acceptableInput, int.Parse(userInput.Last()));
        }

        public static IEnumerable<object[]> AcceptableInputTestsData()
        {
            yield return new object[] { new string[] { "0" } };
            yield return new object[] { new string[] { "", "1" } };
            yield return new object[] { new string[] { "abc", "0" } };
            yield return new object[] { new string[] { "-1", "2", "100", "&*^(*", "0.2", "1" } };
        }
    }
}
