
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TagSampleStudentApi.Models;


namespace SampleDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{


    private readonly TagSampleDbContext _context;

    public StudentController(TagSampleDbContext context)
    {
        _context = context;
    }
    //Get all students records
    [HttpGet("GetAllStudent")]
    
    public async Task<IActionResult> GetAllStudent()
    {
        
        
            throw new Exception("User defined exception here");
        
        //var students = await _context.StudentOriginals.ToListAsync();
        //return Ok(students);
    }
    
    // Get student by Student ID
    [HttpGet("GetbyID")]
    public async Task<IActionResult> GetbyStudentID(string student_Id)
    {
        var student = await _context.StudentOriginals.FindAsync(student_Id);
        return Ok(student);
    }
    //Insert student records
    [HttpPost("Create")]
    public async Task<IActionResult> InsertStudent([FromBody] StudentOriginal _student)
    {
        var student = await _context.StudentOriginals.FindAsync(_student.StudentId);
        if (student != null)
        {
            _context.SaveChanges();
            return Ok(false);
        }
        else
        {
            _context.StudentOriginals.Add(_student);
            _context.SaveChanges();
            return Ok(true);
        }
    }
    //Delete Student records
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteStudent(string student_Id)
    {
        var student = await _context.StudentOriginals.FindAsync(student_Id);
        if (student != null)
        {
            _context.Remove(student);
            _context.SaveChanges();
            return Ok(true);
        }
        else
        {
            return Ok(false);
        }
    }
    //Update the student record
    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateStudent(String student_Id, [FromBody] StudentOriginal _student)
    {
        _context.Update(_student);
        await _context.SaveChangesAsync();
        return Ok(_student);
    }

}