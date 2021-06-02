using DataBase.DBModels;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace DataBase
{
    public class ContextDB : DbContext
    {
       // public DbSet<IEntity> Interface { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Order> Order { get; set; }

        SampleData dataSeed = new SampleData();
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(File.ReadAllText("connection.txt"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(dataSeed.Microsoft);
            modelBuilder.Entity<Employee>().HasData(dataSeed.EmployeesMicrosoft);
            modelBuilder.Entity<Client>().HasData(dataSeed.ClientsMicrosoft);

            modelBuilder.Entity<Company>().HasData(dataSeed.Apple);
            modelBuilder.Entity<Employee>().HasData(dataSeed.EmployeesApple);
            modelBuilder.Entity<Client>().HasData(dataSeed.ClientsApple);
        }
    }
}
