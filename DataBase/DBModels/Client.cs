using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.DBModels
{
    public class Client : IEntity, IShow
    {
       
        public int Id { get; set; }
        [MaxLength(30)]
        public string FirsName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        
        // Navigation
        [ignoreForSelect]
        public int? CompanyId { get; set; }
        [ignoreForSelect]
        public Company Company { get; set; }
        [ignoreForSelect]
        public List <Order> Orders { get; set; }

        public void Show()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"First name: {FirsName}");
            Console.WriteLine($"Last name: {LastName}");
        }
    }
}
