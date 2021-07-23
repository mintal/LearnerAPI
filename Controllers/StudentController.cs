using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnerAPI.Contexts;
using LearnerAPI.DTO;
using LearnerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentsContext _context;

        public StudentController(StudentsContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Obtain all students
        /// </summary>
        /// <returns>All students in DTO form</returns>
        [HttpGet]
        public async Task<List<StudentDTO>> GetAll()
        {
            //todo: move mapping to StudentMapper
            return await _context.Students.Select(s => new StudentDTO
            {
                Initials = s.Initials,
                LastName = s.LastName,
                StudentId = s.StudentId,
                StudentNumber = s.StudentNumber,
                StudyId = s.Study.StudyId
            }).ToListAsync();
        }

        /// <summary>
        ///     Obtain student by Guid
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        //todo change to StudentDTO
        public async Task<ActionResult<Student>> Get(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }

        /// <summary>
        ///     Create a student following the StudentCreateDTO credentials
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns>created student</returns>
        [HttpPost]
        public async Task<ActionResult<Student>> Post(StudentCreateDTO ctx)
        {
            Study study = await _context.Studies.FindAsync(ctx.StudyId);
            Student student = StudentMapper.MapStudent(ctx, study);

            //add to database
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            //return database result
            return await _context.Students.FindAsync(student.StudentId);
        }
    }
}