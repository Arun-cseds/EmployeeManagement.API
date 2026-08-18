namespace EmployeeManagement.Core.DTOs
{
    public  class CreateEmployeeDto
    {

        
            public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }

            public string Email { get; set; } = string.Empty;

            public decimal Salary { get; set; }

            public int DepartmentId { get; set; }

            public int ProjectId { get; set; }

    }
}

