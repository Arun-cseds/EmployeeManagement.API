using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsRequired();


            builder.HasOne(e => e.Department)
                 .WithMany(e => e.Employees)
                 .HasForeignKey(e => e.DepartmentId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Project)
                 .WithMany(e => e.Employees)
                 .HasForeignKey(e => e.ProjectId);

            builder.HasData(

               new Employee
               {
                   EmployeeId = 1,
                   FirstName = "Arun",
                   LastName = "Tiwari",
                   Email = "arun@gmail.com",
                   Salary = 50000,
                  
                   DepartmentId = 1,
                   ProjectId = 1
               },


               new Employee
               {
                   EmployeeId = 2,
                   FirstName = "Rahul",
                   LastName = "Sharma",
                   Email = "rahul@gmail.com",
                   Salary = 60000,
                 
                   DepartmentId = 2,
                   ProjectId = 2
               },


               new Employee
               {
                   EmployeeId = 3,
                   FirstName = "Priya",
                   LastName = "Singh",
                   Email = "priya@gmail.com",
                   Salary = 55000,
                   
                   DepartmentId = 1,
                   ProjectId = 3
               });






        }


    }
}
