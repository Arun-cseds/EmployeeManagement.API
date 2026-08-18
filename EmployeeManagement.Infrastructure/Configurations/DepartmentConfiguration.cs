using EmployeeManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Configurations
{ 
        public class DepartmentConfiguration
            : IEntityTypeConfiguration<Department>
        {
            public void Configure(EntityTypeBuilder<Department> builder)
            {
                

                builder.HasKey(d => d.DepartmentId);


                builder.Property(d => d.DepartmentName)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property(d => d.Description)
                .HasMaxLength(100);



                // Seed Department Data
                builder.HasData(

                    new Department
                    {
                        DepartmentId = 1,
                        DepartmentName = "IT",
                        Description="This is IT Department"
                    },

                    new Department
                    {
                        DepartmentId = 2,
                        DepartmentName = "Human Resource",
                       Description = "This is Human Resource Department"
                    },

                    new Department
                    {
                        DepartmentId = 3,
                        DepartmentName = "Finance",
                        Description = "This is Finance Department"
                    }

                );
            }
        }
    }

