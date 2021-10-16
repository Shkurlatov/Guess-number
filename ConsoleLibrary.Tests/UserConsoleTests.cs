using Xunit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleLibrary.Tests
{
    public class UserConsoleTests
    {
        private readonly int _minNumberValue = 0;
        private readonly int _maxNumberValue = 1;

        [Theory]
        [MemberData(nameof(AcceptableInputTestsData))]
        public void AcceptebleInput_GetInputStrings_LastInputIsAcceptable(string[] userInput)
        {
            // arrange
            Console.SetIn(new StringReader(string.Join('\r', userInput)));

            Type type = typeof(UserConsole);
            var userConsole = Activator.CreateInstance(type, _minNumberValue, _maxNumberValue, false);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "AcceptableInput" && x.IsPrivate)
            .First();

            // act
            int acceptableInput = (int)method.Invoke(userConsole, new object[] { _minNumberValue, _maxNumberValue });

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
