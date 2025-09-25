using Day05Lab_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day05Lab_Model.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            var employees = new List<Employee>
            {
                new Employee { Id=1, FullName="Nguyễn Văn A", Gender="Male", Phone="0912345678", Email="vana@example.com", Salary=15000000, Status="Active" },
                new Employee { Id=2, FullName="Trần Thị B", Gender="Female", Phone="0987654321", Email="thib@example.com", Salary=12000000, Status="Active" },
                new Employee { Id=3, FullName="Lê Văn C", Gender="Male", Phone="0901122334", Email="vanc@example.com", Salary=10000000, Status="Inactive" }
            };

            return View(employees);
        }
    }
}
