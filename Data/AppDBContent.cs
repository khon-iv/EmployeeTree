using Microsoft.EntityFrameworkCore;
using EmployeeTree.Data.Models;

namespace EmployeeTree.Data
{
    public class AppDBContent: DbContext
    {
       
        public AppDBContent() 
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;DataBase=CompanyNameDataBase;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
    }
}
