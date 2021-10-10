using System;
using System.ComponentModel;
using System.Reflection;

namespace ConsoleLibrary
{
    public enum Messages
    {
        [Description("Hello! I thought a number from {0} to {1}. Try to guess.")]
        GreetingsAndStart,
        [Description("\nMy number is less. Please try again.")]
        NumberIsLess,
        [Description("\nMy number is more. Please try again.")]
        NumberIsMore,
        [Description("\nCongratulations, you guessed the number on try #{0}.")]
        Congratulations,
        [Description("\nPlease enter 1 if you want to start a new game or 0 if you not.")]
        RestartOrNot,
        [Description("Well, I thought another number from {0} to {1}. Try to guess.")]
        StartNewGame,
        [Description("\nPlease enter an intager from {0} to {1}.")]
        InputIsIncorrect,
    }

    static class ExtensionClass
    {
        public static string GetDescription(this Enum e)
        {
            Type eType = e.GetType();
            string eName = Enum.GetName(eType, e);
            if (eName != null)
            {
                FieldInfo fieldInfo = eType.GetField(eName);
                if (fieldInfo != null)
                {
                    DescriptionAttribute descriptionAttribute =
                           Attribute.GetCustomAttribute(fieldInfo,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
            }
            return String.Empty;
        }
    }
}
