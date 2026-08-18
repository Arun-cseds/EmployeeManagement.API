namespace EmployeeManagement.Core.Entities
{
    public  class Department
    {

        // Primary Key
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // Navigation Property
        // One Department -> Many Employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
