using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace DataBase.DBModels
{
    public class Employee : IEntity, IShow
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string FirsName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string Position { get; set; }
        [MaxLength(6)]
        public int Salary { get; set; }

        // Navigation
        [ignoreForSelect]
        public int? CompanyId { get; set; }
        [ignoreForSelect]
        public Company Company { get; set; }
        [ignoreForSelect]
        public List<Order> Orders { get; set; }
        public void Show()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"First name: {FirsName}");
            Console.WriteLine($"Last name: {LastName}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }

}
