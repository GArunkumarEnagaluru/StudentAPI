using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.Include(s => s.ExamResult).ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.Include(s => s.ExamResult).FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(StudentPostModel studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                SchoolName = studentDto.SchoolName,
                ExamResult = studentDto.ExamResult != null ? new ExamResult
                {
                    English = studentDto.ExamResult.English,
                    Telugu = studentDto.ExamResult.Telugu,
                    Hindi = studentDto.ExamResult.Hindi,
                    Mathematics = studentDto.ExamResult.Mathematics,
                    Physics = studentDto.ExamResult.Physics,
                    Social = studentDto.ExamResult.Social
                } : null
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // PATCH: api/Students/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStudent(int id, [FromBody] Student studentUpdate)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            if (studentUpdate.Name != null)
            {
                student.Name = studentUpdate.Name;
            }

            if (studentUpdate.SchoolName != null)
            {
                student.SchoolName = studentUpdate.SchoolName;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
