using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.DBModels
{
    public class Order : IEntity, IShow
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public int Sum { get; set; }
        public int ClientrId { get; set; }
        public int EmployeeId { get; set; }

        public void Show()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Order sum: {Sum}");
            Console.WriteLine($"Client Id: {ClientrId}");
            Console.WriteLine($"Employee id: {EmployeeId}");
        }
    }
}
