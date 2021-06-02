using System;
using System.Collections.Generic;
using System.Reflection;

namespace DBOptions.GUI.GUIFunctions
{
    internal static class EntityFunctionsHelper<T>
    {
        //======================================================================================================================//
        internal static int SelectProperty(PropertyInfo[] properties, string entityName)
        {
            // Show all properties
            WriteLineExtension.GreenMessage($"\nSelect field for {entityName}:\n");
            int i = 1;
            foreach (var property in properties)
            {
                Console.WriteLine($"{i++}) {property.Name}");
            }
            // Select property 
            var userValue = Console.ReadKey();
            int propertyNumber;
            while (!int.TryParse(userValue.KeyChar.ToString(), out propertyNumber) && propertyNumber > 0 && propertyNumber <= properties.Length)
            {
                WriteLineExtension.RedMessage($"\n Use number from 1 to {properties.Length}");
                userValue = Console.ReadKey();
            }
            return propertyNumber;
        }
        //======================================================================================================================//
        internal static int SelectFromList(List<T> list)
        {
            if (list.Count == 1)
                return 1;
            int choice;
            while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out choice) && choice > 0 && choice <= list.Count)
            {
                WriteLineExtension.RedMessage($"\n Use number from 1 to {list.Count}");
            }
            return choice;
        }
        //======================================================================================================================//
        internal static string EnterPropertyValue(PropertyInfo[] properties, int propertyNumber)
        {
            WriteLineExtension.GreenMessage($"\nEnter {properties[propertyNumber - 1].Name}: ");
            var userValue = Console.ReadLine();
            if (properties[propertyNumber-1].PropertyType == typeof(Int32))
            {
                int intValue = IntCheck(userValue, $"Enter {properties[propertyNumber - 1].Name}: ");
                return (intValue.ToString());
            }
            return (userValue);
        }
        //======================================================================================================================//
        internal static int IntCheck(string checkValue, string userInstruction)
        {
            int intValue;
            while (!int.TryParse(checkValue, out intValue))
            {
                WriteLineExtension.RedMessage("Invalid value! Please use number from 0 to 9");
                WriteLineExtension.GreenMessage(userInstruction);
                checkValue = Console.ReadLine();
            }
            return intValue;
        }
    }
}
