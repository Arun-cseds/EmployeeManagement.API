namespace EmployeeManagement.Core.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

        public string ProjectName { get; set; } = string.Empty;
    }
}
