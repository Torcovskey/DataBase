using System;
using DataBase;
using DBOptions.GUI;

using DBOptions.GUI.GUIFunctions;

namespace DBOptions
{
    public class StartMenu
    {
        public  void Start(ContextDB dbContext)
        {
            Console.Clear();
            bool exit = false;
            MenuFunctions function = new MenuFunctions();
            while (!exit)
            {
                WriteLineExtension.GreenMessage("\t Welcome to my DataBase ");
                bool endWhile = false;
                while (!endWhile)
                {
                    Console.WriteLine("\nSelect function:");
                    WriteLineExtension.RedMessage("0 - Exit");
                    Console.WriteLine("1 - Add \t  2 - Update");
                    Console.WriteLine("3 - Delete \t  4 - Select");
                    var num = Console.ReadKey();
                    switch (num.KeyChar)
                    {
                        case '1':   function.ComandMenu(ref exit, dbContext, Commands.Add);    break;
                        case '2':   function.ComandMenu(ref exit, dbContext, Commands.Update); break;
                        case '3':   function.ComandMenu(ref exit, dbContext, Commands.Delete); break;
                        case '4':   function.ComandMenu(ref exit, dbContext, Commands.Select); break;
                        case '0':   endWhile = true; exit = true; break;
                        default:    WriteLineExtension.RedMessage("Invalid value"); break;
                    }
                }
            }
        }
    }
}
