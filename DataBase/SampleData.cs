using DataBase.DBModels;
using System.Collections.Generic;
namespace DataBase
{
    public  class SampleData
    {
        public  List<Employee> EmployeesMicrosoft = new List<Employee>()
        {
            new Employee() 
            {
                Id = 1,
                CompanyId = 1,
                FirsName = "Vasiliy", 
                LastName = "Pupkin", 
                Position = "junior C#", 
                Salary = 45000                
            },
            new Employee() 
            { 
                Id = 2,
                CompanyId = 1,
                FirsName = "Alex", 
                LastName = "Chpokin", 
                Position = "junior java", 
                Salary = 47000
            },
            new Employee() 
            { 
                Id = 3,
                CompanyId = 1,
                FirsName = "Geralt", 
                LastName = "Vedmak",
                Position = "Middle C#", 
                Salary = 130000
            },
            new Employee() 
            { 
                Id = 4,
                CompanyId = 1,
                FirsName = "Artemi", 
                LastName = "Lebedev", 
                Position = "Designer", 
                Salary = 250000
            },
            new Employee() 
            { 
                Id = 5,
                CompanyId = 1,
                FirsName = "Ulrikh", 
                LastName = "Petrel", 
                Position = "Senior java", 
                Salary = 310000
            },
            new Employee() 
            { 
                Id = 6,
                CompanyId = 1,
                FirsName = "Vladimir", 
                LastName = "Putin",
                Position = "President", 
                Salary = 666666
            }
        };

        public  List<Client> ClientsMicrosoft = new List<Client>()
        {
            new Client() 
            { 
                Id = 1,
                CompanyId = 1,
                FirsName = "Jorik", 
                LastName = "Vartatov", 
            },
            new Client()
            { 
                Id = 2, 
                CompanyId = 1,
                FirsName = "Pupa", 
                LastName = "Lupa",
            },
            new Client() 
            { 
                Id = 3,
                CompanyId = 1,
                FirsName = "Donald", 
                LastName = "Trump", 
            }
        };

        public  List<Employee> EmployeesApple = new List<Employee>()
        {
            new Employee() 
            { 
                Id = 7,
                CompanyId = 2,
                FirsName = "Peter",
                LastName = "Parker",
                Position = "Photographer", 
                Salary = 76000
            },
            new Employee() 
            { 
                Id = 8,
                CompanyId = 2,
                FirsName = "Bruce", 
                LastName = "Wayne", 
                Position = "Brand manager", 
                Salary = 640000
            },
            new Employee() 
            { 
                Id = 9,
                CompanyId = 2,
                FirsName = "Clark", 
                LastName = "Kent", 
                Position = "Superman", 
                Salary = 17500 
            },
            new Employee() 
            { 
                Id = 10,
                CompanyId = 2,
                FirsName = "Tony", 
                LastName = "Stark",
                Position = "Team Lead", 
                Salary = 666665 
            },
            new Employee() 
            {
                Id = 11,
                CompanyId = 2,
                FirsName = "John",
                LastName = "Connor",
                Position = "Machine Learning Engineer", 
                Salary = 284600
            },
            new Employee() 
            { 
                Id = 12,
                CompanyId = 2,
                FirsName = "Vladimir",
                LastName = "Zelensky",
                Position = "President",
                Salary = 666666
            }
        };
        public  List<Client> ClientsApple = new List<Client>()
        {
            new Client()
            { 
                Id = 4,
                CompanyId = 2,
                FirsName = "Hot", 
                LastName = "Dog",
            },
            new Client() 
            {
                Id = 5,
                CompanyId = 2,
                FirsName = "John",
                LastName = "Wick",
            },
            new Client() 
            { 
                Id = 6,
                CompanyId = 2,
                FirsName = "Justin", 
                LastName = "Bieber",
            }
        };

        public  Company Microsoft = new Company() 
        { 
            CompanyName = "Microsoft", 
            Id = 1 
        };

        public  Company Apple = new Company() 
        { 
            CompanyName = "Apple", 
            Id = 2
        };
    }
}
