using EmployeeTree.Data;
using EmployeeTree.Data.Models;
using EmployeeTree.ViewModels;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Xml.Linq;

namespace EmployeeTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Employee> employees = EmployeeDB.GetAllEmployees().Where(e => e.Marked == false).ToList();

            return View(employees);
        }

        public Employee? Employee(int id)
        {
            Employee? employee = EmployeeDB.GetEmployee(id);
            return employee;
        }

        public Dictionary<int, Node> GetEmployees()
        {
            List<Employee> employees = EmployeeDB.GetAllEmployees().Where(e => e.Marked == false).ToList();
            Dictionary<int, Node> nodes = new();

            foreach (Employee employee in employees)
            {
                if (employee.HeadId == 0)
                {
                    nodes.Add(employee.Id, new Node() { value = employee.FullName, parent = "", id = employee.Id.ToString() });
                }
                else
                {
                    nodes.Add(employee.Id, new Node() { value = employee.FullName, parent = employee.HeadId.ToString(), id = employee.Id.ToString() });
                }
            }

            return nodes;
        }

        public RedirectToActionResult Delete(int id)
        {
            Employee? employee = EmployeeDB.GetEmployee(id);
            if (employee != null)
            {
                if (employee.Marked)
                {
                    EmployeeDB.Remove(employee);
                }
                else
                {
                    //удаляемый сотрудник не уволен
                }
            }
            else
            {
                //что удаляемый сотрудник не найден
            }
            return RedirectToAction("Index");
        }

        private bool IsSubject(List<Employee> subjects, Employee employee)
        {
            foreach (Employee subject in subjects)
            {
                if (subject.Equals(employee)) return true;
            }
            return false;
        }

        public RedirectToActionResult Fire(int id, int? newHeadId)
        {
            Employee? markedEmployee = EmployeeDB.GetEmployee(id);
            if (markedEmployee != null)
            {
                List<Employee> subjects = EmployeeDB.GetAllEmployees().Where(e => e.HeadId == id && e.Marked == false).ToList();

                if (subjects.Count > 0)
                {
                    if (newHeadId != null)
                    {
                        Employee? newHead = EmployeeDB.GetEmployee((int)newHeadId);
                        if (newHead != null)
                        {
                            if (IsSubject(subjects, newHead))
                            {
                                newHead.HeadId = markedEmployee.HeadId;
                                EmployeeDB.Update(newHead);
                                subjects.Remove(newHead);

                                foreach (Employee subject in subjects)
                                {
                                    subject.HeadId = (int)newHeadId;
                                    EmployeeDB.Update(subject);
                                }


                                markedEmployee.Marked = true;
                                EmployeeDB.Update(markedEmployee);
                            }
                            else
                            {
                                //новый руководитель не является подчиненным
                            }
                        }
                        else
                        {
                            //увольняемый сотрудник занимает руководящую должность, а id нового руководиетля нет в бд
                        }
                    }
                    else
                    {
                        //увольняемый сотрудник занимает руководящую должность, а замена не указана
                    }
                }
                else
                {
                    markedEmployee.Marked = true;
                    EmployeeDB.Update(markedEmployee);

                    if (newHeadId != null)
                    {
                        //увольняемый сотрудник не занимал руководящую должность
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult EmployeeTree()
        {
            List<Employee> employees = EmployeeDB.GetAllEmployees().Where(e => e.Marked == false).ToList();
            return View(employees);
        }

        public RedirectToActionResult Hire(string fullName, string position, int headId)
        {
            Employee? head = EmployeeDB.GetEmployee(headId);
            if (head != null || (EmployeeDB.GetAllEmployees().IsNullOrEmpty() && (headId == 0)))
            {
                Employee employee = new Employee
                {
                    FullName = fullName,
                    Position = position,
                    HeadId = headId,
                    Marked = false
                };
                EmployeeDB.Add(employee);
            }
            else
            {
                //руководитель не найден в базе
            }
            return RedirectToAction("Index");
        }
    }
}
