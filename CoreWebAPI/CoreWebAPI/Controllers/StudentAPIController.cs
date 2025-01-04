using CoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentDbContext _context;
        public StudentAPIController(StudentDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var data=await _context.Students.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(long id)
        {
            var student=await _context.Students.FindAsync(id);
            if(student==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await _context.Students.AddAsync(std);
            await _context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id,Student std)
        {
            if(id!=std.Id)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(std).State= EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(std);
            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(long id)
        {
            var std = await _context.Students.FindAsync(id);
            if(std==null)
            {
                return NotFound();
            }
            else
            {
                _context.Students.Remove(std);
                await _context.SaveChangesAsync();
                return Ok();
            }
           
        }

    }
}
