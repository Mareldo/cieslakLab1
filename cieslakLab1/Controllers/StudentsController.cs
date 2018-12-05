using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cieslakLab1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cieslakLab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public List<Student> students = new List<Student>
        {
            new Student() { Id = 1, FirstName = "Ala", LastName = "Kot", Grant = 1234 },
            new Student() { Id = 2, FirstName = "Tomek", LastName = "Kowalski", Grant = 2345}
        };
        // GET: api/Students
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetStudent(int id)
        {
            var student = students.SingleOrDefault(s => s.Id == id);
            if (student != null)
                return Ok(student);
            else
                return NotFound();
        }

        // POST: api/Students
        [HttpPost]
        public IActionResult PostStudent([FromBody] Student student)
        {
            student.Id = students.Last().Id + 1;
            students.Add(student);
            return CreatedAtRoute("Get", new { id = student.Id }, student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
