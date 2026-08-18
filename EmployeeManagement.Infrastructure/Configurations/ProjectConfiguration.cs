using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManagement.Core.Entities;

namespace EmployeeManagement.Infrastructure.Configurations
{
    public class ProjectConfiguration:IEntityTypeConfiguration<Project>
    {


        void IEntityTypeConfiguration<Project>.Configure(EntityTypeBuilder<Project> builder)
        {

            builder.HasKey(p => p.ProjectId);


            builder.Property(p => p.ProjectName)
                .HasMaxLength(100)
                .IsRequired();



           

            


            // Seed Data

            builder.HasData(

                new Project
                {
                    ProjectId = 1,
                    ProjectName = "Employee Management API",
                    Budget = 500000

                },


                new Project
                {
                    ProjectId = 2,
                    ProjectName = "Banking Application",
                    Budget = 800000
                    
                },


                new Project
                {
                    ProjectId = 3,
                    ProjectName = "E-Commerce Platform",
                    Budget = 1000000
                } 

            );



        }
    }
}
