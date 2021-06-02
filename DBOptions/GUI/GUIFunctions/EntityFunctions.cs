using DataBase;
using System;
using DataBase.DBModels;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace DBOptions.GUI.GUIFunctions
{
    internal class EntityFunctions <T> where T : class, IEntity, IShow, new()
    {
        //======================================================================================================================//
        private PropertyInfo[] Properties;
        private string EntityName;
        private Type Type;
        //======================================================================================================================//
        internal EntityFunctions ()
        {
            Properties = typeof(T)
                .GetProperties()
                .Where(x => !x.CustomAttributes
                .Any(a => a.AttributeType == typeof(ignoreForSelect)))
                .ToArray();

            EntityName = typeof(T).Name;
            Type = typeof(T);
        }
        //======================================================================================================================//
        internal void Add(ContextDB dbContext)
        {
            Console.Clear();
            T newModel = new T();
            foreach (var property in Properties)
            {
                if (property.Name != "Id")
                {
                    WriteLineExtension.GreenMessage($"Enter {property.Name}: ");
                    var userValue = Console.ReadLine();
                    if (property.PropertyType == typeof(Int32))
                    {
                        var userIntValue = EntityFunctionsHelper<T>.IntCheck(userValue, $"Enter { property.Name}: ");
                        property.SetValue(newModel, userIntValue);
                    }
                    else 
                    {
                        property.SetValue(newModel, userValue);
                    }
                }
            }
            dbContext.Add(newModel);
            dbContext.SaveChanges();
            WriteLineExtension.GreenMessage("Completed successful");
            WriteLineExtension.WaitUser();
        }
        //======================================================================================================================//
        internal void Delete(ContextDB dbContext)
        {
            Console.Clear();
            var findResult = Select(dbContext);
            while (findResult.Count < 1)
            {
                findResult = Select(dbContext);
            }
            foreach(var model in findResult)
            {
                model.Show();
            }
            int choice = EntityFunctionsHelper<T>.SelectFromList(findResult);
            WriteLineExtension.GreenMessage("Sure to delete?\n\n Press \"Y\" if yes");
            if (Console.ReadKey().KeyChar.ToString() == "y")
            {
                dbContext.Remove(findResult[choice - 1]);
                dbContext.SaveChanges();
                WriteLineExtension.GreenMessage("Completed successfully");
                WriteLineExtension.WaitUser();
            }
        }
        //======================================================================================================================//
        internal List<T> Select(ContextDB dbContext)
        {
            Console.Clear();
            int num = EntityFunctionsHelper<T>.SelectProperty(Properties, EntityName);
            string value = EntityFunctionsHelper<T>.EnterPropertyValue(Properties, num);
            int temp;
            List<T> findResult;
            if (!int.TryParse(value, out temp))
            {
                 findResult = dbContext
                    .Set<T>()
                    .WhereDynamic(e => $"e.{Properties[num - 1].Name}.Contains(\"{value}\")").ToList();
            }
            else
            {
                 findResult = dbContext
                    .Set<T>()
                    .WhereDynamic(i => $"i.{Properties[num - 1].Name} == {temp}").ToList();
            }
            if (findResult.Count < 1 || findResult == null)
            {
                WriteLineExtension.RedMessage($"{Type.Name} with {Properties[num - 1].Name}: \"{value}\" not exist");
                WriteLineExtension.WaitUser();
            }
            else
            {
                foreach (var model in findResult)
                {
                    Console.Clear();
                    model.Show();
                    WriteLineExtension.GreenMessage("--//--//--//--");
                }
                WriteLineExtension.WaitUser();
            }
            return findResult;
        }
        //======================================================================================================================//
        internal void Update(ContextDB dbContext)
        {
            Console.Clear();
            var findResult = Select(dbContext);
            while (findResult.Count < 1)
            {
                findResult = Select(dbContext);
            }
            int choice = EntityFunctionsHelper<T>.SelectFromList(findResult);
            int propNum = EntityFunctionsHelper<T>.SelectProperty(Properties, EntityName);
            string change = EntityFunctionsHelper<T>.EnterPropertyValue(Properties, propNum);
            if (Properties[propNum-1].PropertyType == propNum.GetType())
            {
                int changeInt = Convert.ToInt32(change);
                Properties[propNum - 1].SetValue(findResult[choice - 1], changeInt);
            }
            else
            {
                Properties[propNum - 1].SetValue(findResult[choice - 1], change);
            }
            dbContext.SaveChanges();
            WriteLineExtension.GreenMessage("Completed successful");
            WriteLineExtension.WaitUser();
        }
    }
}
