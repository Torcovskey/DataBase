using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace DataBase.DBModels
{
    public class Company : IEntity, IShow
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string CompanyName { get; set; }
        [ignoreForSelect]
        public List <Employee> Employers { get; set; }
        [ignoreForSelect]
        public List <Client> Clients { get; set; }
        public void Show()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Company name: {CompanyName}");
        }
    }
}
