using FullStackCrud.Data;
using FullStackCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FullStackCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly DBClass _dbClass;
        public StudentsController(DBClass dbClass)
        {
            this._dbClass = dbClass;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var student = await _dbClass.students.ToListAsync();
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmploy([FromBody] Student studentObj)
        {
            studentObj.id = new System.Guid();
            await _dbClass.students.AddAsync(studentObj);
            await _dbClass.SaveChangesAsync();
            return Ok(studentObj);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetStudents([FromRoute] Guid id)
        {
            var student = await _dbClass.students.FirstOrDefaultAsync(x => x.id == id);



            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, Student studentobj)
        {
            var student = await _dbClass.students.FindAsync(id);



            if (student == null)
            {
                return NotFound();
            }
            student.name = studentobj.name;
            student.fatherName = studentobj.fatherName;
            student.cgpa = studentobj.cgpa;
            student.degree = studentobj.degree;
            student.standar = studentobj.standar;
            student.section = studentobj.section;
            student.id = studentobj.id;
            student.fees = studentobj.fees;
            student.rollNo = studentobj.rollNo;
            student.contact = studentobj.contact;
            _dbClass.SaveChanges();
            return Ok(student);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var student = await _dbClass.students.FindAsync(id);



            if (student == null)
            {
                return NotFound();
            }
            _dbClass.students.Remove(student);

            _dbClass.SaveChanges();
            return Ok(student);

        }
    }
}
