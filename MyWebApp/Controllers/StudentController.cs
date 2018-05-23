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

            
            return View();
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        public ActionResult EditStudent()
        {
            return View();
        }

        public ActionResult DeleteStudent()
        {
            return RedirectToAction("Index");
        }
    }
}