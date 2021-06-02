using System;

namespace DBOptions.GUI.GUIFunctions
{
    public static class WriteLineExtension
    {
        public static void RedMessage(string messageText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(messageText);
            Console.ResetColor();
        }
        public static void GreenMessage(string messageText)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(messageText);
            Console.ResetColor();
        }
        public static void WaitUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
