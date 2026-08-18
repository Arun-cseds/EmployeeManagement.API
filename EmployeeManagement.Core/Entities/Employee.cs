namespace EmployeeManagement.Core.Entities
{
    public class Employee
    {

        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }= string.Empty;

       public string Email { get; set; }= string.Empty;

        public Decimal Salary {  get; set; }

    

        //Foreign key
        public int DepartmentId {  get; set; }

        public Department? Department { get; set; }

         public int ProjectId { get; set; }

        public Project  ? Project { get; set; }








    }
}
