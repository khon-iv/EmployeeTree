namespace EmployeeTree.Data.Models
{
    public class Employee : IEquatable<Employee>
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Position { get; set; }
        public int HeadId { get; set; }
        public bool Marked { get; set; }

        public bool Equals(Employee? other)
        {
            if (other != null)
            {
                if (other.Id == Id) return true;
            }
            return false;
        }
    }
}
