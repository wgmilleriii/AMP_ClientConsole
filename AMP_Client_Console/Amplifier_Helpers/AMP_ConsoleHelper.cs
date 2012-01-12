using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amplifier_Helpers
{


    public static class AMP_ConsoleHelper
    {

        /// <summary>
        /// Displays a beautiful messagebox in the console.  Whee!
        /// </summary>
        public static void ShowMessageBox(string message)
        {
            ShowMessageBox(message, 80, '-');
        }

        /// <summary>
        /// Displays a beautiful messagebox in the console.  Whee!
        /// </summary>
        public static void ShowMessageBox(string message, int messageBoxWidth) {
            ShowMessageBox(message, messageBoxWidth, '-');
        }

        /// <summary>
        /// Displays a beautiful messagebox in the console.  Whee!
        /// </summary>
        public static void ShowMessageBox(string message, int messageBoxWidth, char border)
        {
            if (message.Length % 2 != 0) message += " ";
            int halfWidth = (messageBoxWidth - 2 - message.Length) / 2;
            string halfWidthMessage = new string(' ', halfWidth);
            string borderLine = new string(border, messageBoxWidth);
            string blankLine = new string(' ', messageBoxWidth - 2);

            Console.WriteLine();
            Console.WriteLine(borderLine);
            Console.WriteLine("|" + blankLine + "|");
            Console.WriteLine("|" + halfWidthMessage + message + halfWidthMessage + "|");
            Console.WriteLine("|" + blankLine + "|");
            Console.WriteLine(borderLine);
            Console.WriteLine();

        }

    }
}
