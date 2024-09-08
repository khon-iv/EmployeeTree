using EmployeeTree.Data.Models;

namespace EmployeeTree.Data
{
    static class EmployeeDB
    {
        public static void Add(Employee employee)
        {
            using (AppDBContent db = new AppDBContent())
            {
                try
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                } catch
                {
                    Console.WriteLine("exeption");
                }
            }
        }

        public static List<Employee> GetAllEmployees()
        {
            using (AppDBContent db = new AppDBContent())
            {
                List<Employee> employees = new List<Employee>();
                foreach(Employee employee in db.Employees)
                {
                    employees.Add(employee);
                }
                return employees;

            }
        }

        public static void Remove(Employee employee)
        {
            using (AppDBContent db = new AppDBContent())
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                    
            }
        }

        public static Employee? GetEmployee(int id)
        {
            using (AppDBContent db = new AppDBContent())
            {
                foreach (Employee employee in db.Employees)
                {
                    if (employee.Id == id)
                        return employee;
                }
            }
            return null;
        }

        public static List<Employee> GetSubjects(IEnumerable<Employee> employees, int headId)
        {
            List<Employee> subjects  = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.HeadId == headId)
                    subjects.Add(employee);
            }
            return subjects;
        }

        public static void Update(Employee employee)
        {
            using (AppDBContent db = new AppDBContent())
            {
                db.Employees.Update(employee);
                db.SaveChanges();
            }
        }
    }
}
