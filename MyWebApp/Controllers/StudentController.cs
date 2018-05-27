using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyWebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        // GET: Student
        public async Task<ActionResult> Index()
        {
            var students = await _studentService.GetStudents();

            
            return View(students);
        }

        public ActionResult AddStudent()
        {
            var studentViewModel = new StudentViewModel
            {
                Title = "Add New Student",
                AddButtonTitle = "Add",
                RedirectUrl = Url.Action("Index", "Student")
            };
            return View(StudentViewModel);
        }

        public async Task<ActionResult> DetailsOfStudent(int id)
        {
            var student = await _studentService.GetStudentAsync(id);
            return View(new StudentViewModel { Id = student.StudentID, Name = student.StudentName});
        }

        [HttpPost]
        public async Task<ActionResult> SaveStudent(StudentViewModel studentViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(studentViewModel);
            }

            var student = await _studentService.GetStudentAsync(studentViewModel.Id);
            if (student != null)
            {
                student.StudentName = studentViewModel.Name;

                await _studentService.UpdateStudentAsync(student);
            }

            return RedirectToLocal(redirectUrl);
        }

        public ActionResult DeleteStudent()
        {
            return RedirectToAction("Index");
        }
    }
}