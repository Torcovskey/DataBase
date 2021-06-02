using System;
using DBOptions.GUI.GUIFunctions;
using DataBase;
using DataBase.DBModels;


namespace DBOptions.GUI
{
    public class MenuFunctions
    {
        public void ComandMenu(ref bool exit, ContextDB dbContext, string command)
        {
            bool endWhile = false;
            while (endWhile != true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------------------------");
                Console.WriteLine($"-------{command} Menu-------");
                Console.WriteLine("-------------------------\n");
                Console.ResetColor();

                Console.WriteLine($"What do you want to {command}? \n");
                Console.WriteLine(" 1 - Company   2 - Client");
                Console.WriteLine(" 3 - Employee  4 - Order");
                Console.WriteLine(" 9 - Back      0 - Exit");

                var choice = Console.ReadKey();
                switch (choice.KeyChar)
                {
                    case '1':   WhatCommand<Company>(command, dbContext);break;
                    case '2':   WhatCommand<Client>(command, dbContext);break;
                    case '3':   WhatCommand<Employee>(command, dbContext);break;
                    case '4':   WhatCommand<Order>(command, dbContext); break;
                    case '9':   endWhile = true;break;
                    case '0':   exit = true;endWhile = true;break;
                    default:    WriteLineExtension.RedMessage("Invalid value");break;
                }
            }
        }
        private void WhatCommand <T> (string command, ContextDB dbContext) 
            where T : class, IEntity, IShow, new()
        {
            var Functions = new EntityFunctions<T>();
              switch(command)
            {
                case Commands.Delete:   Functions.Delete(dbContext); break;
                case Commands.Add:      Functions.Add(dbContext);    break;
                case Commands.Update:   Functions.Update(dbContext); break;
                case Commands.Select:   Functions.Select(dbContext); break;
            }
        }
    }
}
