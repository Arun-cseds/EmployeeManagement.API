namespace EmployeeManagement.Core.Entities
{
    public  class Project
    {
        // Primary Key
        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public decimal Budget { get; set; }

       
        // Navigation Property
        // One Project -> Many Employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();


    }
}
