using Day12Lab_Th1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day12Lab_Th1.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student()
                {
                    Id=101,
                    Name="Tus",
                    Branch= Branch.IT,
                    Gender = Gender.Female,
                    IsRegular=true,
                    Address= "Ninh binh",
                    Email="alice@gmail.com"},
                new Student()
                {
                    Id=102,
                    Name="Tuan",
                    Branch= Branch.CE,
                    Gender = Gender.Male,
                    IsRegular=true,
                    Address= "Nam Dinhh",
                    Email="tuan1@gmail.com"},
                new Student()
                {
                    Id=103,
                    Name="tung",
                    Branch= Branch.EE,
                    Gender = Gender.Female,
                    IsRegular=false,
                    Address= "Ninh binh",
                    Email="tung2@gmail.com"},
                new Student()
                {
                    Id=104,
                    Name="son",
                    Branch= Branch.BE,
                    Gender = Gender.Male,
                    IsRegular=false,
                    Address= "ha noi",
                    Email="son3@gmail.com"} };

        }
        [Route("List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }
        [HttpGet]
        [Route("Add")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>() { new SelectListItem{Text = "IT", Value = "1"},
                new SelectListItem{Text = "BE", Value = "2"},
                new SelectListItem{Text = "CE", Value = "3"},
                new SelectListItem{Text = "EE", Value = "4"}

            };
            return View();
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Create(Student student, IFormFile Avatar)
        {
            if (Avatar != null && Avatar.Length > 0)
            {
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadDir))
                    Directory.CreateDirectory(uploadDir);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Avatar.FileName);
                var filePath = Path.Combine(uploadDir, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Avatar.CopyTo(stream);
                }

                student.AvatarFileName = fileName;
            }
            student.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(student);
            return View("Index", listStudents);
        }
    }
}
