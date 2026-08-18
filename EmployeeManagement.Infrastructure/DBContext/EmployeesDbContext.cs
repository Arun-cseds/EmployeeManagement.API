
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagement.Infrastructure.DBContext
{
    public class EmployeesDbContext:DbContext
    {
        

        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options):
            base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; } 

        public DbSet<Department> Departments { get; set; } 

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users {  get; set; }

        protected override void OnModelCreating(
    ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.ApplyConfiguration(
                new EmployeeConfiguration());



            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration()) ;
        }



    }
}
