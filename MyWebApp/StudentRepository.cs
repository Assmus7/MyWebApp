using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApp.Models;

namespace MyWebApp
{
    public class StudentRepository
    {
        private readonly List<Student> _students;

        public StudentRepository()
        {
            _students = new List<Student>() { new Student { Id = 1, Email = "kolyanupasik@gmail.com", FirstName = "Nikolay", LastName = "Larin" } };
        }

        public async Task<List<Student>> GetStudents()
        {
            return await Task.Run(() => _students);
        }

        public async Task<Student> GetStudents(int id)
        {
            return await Task.Run(() => _students.FirstOrDefault(f => f.Id == id));
        }

        //public async Task<Student> AddStudent(Student student)
        //{
        //    _students.Add(student);
        //    return ;
        //}
    }

}