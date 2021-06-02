
using DataBase;


namespace DBOptions
{
    class Program
    {
        static void Main(string[] args)
        {
            StartMenu start = new StartMenu();
            using (ContextDB dbContext = new ContextDB())
            {
                start.Start(dbContext);
            }
        }
    }
}
